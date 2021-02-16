import { AfterViewChecked, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { debug } from 'console';
import { LoginChat } from '../modelos/chat.login';
import { MessageTypeEnum } from '../modelos/enum/MessageTypeEnum';
import { MessageDTO } from '../modelos/mensagem.model';
import { ChatService } from './chat.service';
declare var $: any

@Component({
  selector: 'bt-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit, AfterViewChecked  {

  public messageTypeEnumRef: typeof MessageTypeEnum;
    public chatMessages: MessageDTO[];
    // public sendMessageIcon: IconDefinition;
    // public leaveChatIcon: IconDefinition;
    public liveChatOn: boolean;

    @ViewChild('messagesContainer')
    private _messagesContainer: ElementRef;
    private _liveChatService: ChatService;
    private _router: Router;
    private _activatedRoute: ActivatedRoute;

    formularioEntrada: FormGroup
    login: LoginChat

  constructor(liveChatService: ChatService, router: Router, route: ActivatedRoute, formBuilder: FormBuilder) {
    this.chatMessages = [];
        this.messageTypeEnumRef = MessageTypeEnum;
        this._activatedRoute = route;
        this._liveChatService = liveChatService;
        this._router = router;
        this.liveChatOn = false;

        this.formularioEntrada = formBuilder.group({
          userName: ''
        });

        // this.sendMessageIcon = faArrowAltCircleRight;
        // this.leaveChatIcon = faSignOutAlt;
   }

   public ngAfterViewChecked(): void {
      if (this._messagesContainer && this.chatMessages.length > 0){
          this.scrollPageToBottom()
      }
    }

  ngOnInit(): void {
    $('#modalLoginChat').modal('show'); 
  }

  public sendNewMessage(messageInput: HTMLInputElement): void {
    const messageContent = messageInput.value;
    const currentUserName = this._liveChatService.CurrentUserName;
    const newMessage = new MessageDTO(currentUserName, messageContent, MessageTypeEnum.CurrentUserMessage);
    this.chatMessages.push(newMessage);
    this._liveChatService.sendNewMessage(messageContent);
    messageInput.value = '';
    }

    public leaveChatAsync(): void {
        this._liveChatService.leaveChatAsync()
        .then(() => {
            this.liveChatOn = false;
            this._router.navigate(['']);
        });
    }

    private scrollPageToBottom(): void {
        this._messagesContainer.nativeElement.scrollTop =
        this._messagesContainer.nativeElement.scrollHeight;
    }

    entrarUsuario(){
      this.login = Object.assign(new LoginChat(), this.formularioEntrada.value)
      $('#modalLoginChat').modal('toggle'); 
      this.formularioEntrada.reset()
      this.iniciar(this.login)
    }

  iniciar(login: LoginChat) {
    const userName = login.userName;
      this._liveChatService.initializeNewUserConnectionAsync(userName)
          .then(() => {
              this.liveChatOn = true;
          });
    

    this._liveChatService.newMessageReceivedEvent.subscribe((newMessage: MessageDTO) => {
        this.chatMessages.push(newMessage);
    });
  }

}
