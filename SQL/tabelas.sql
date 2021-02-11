
CREATE TABLE TBL_PROCESSOS(
	ID INT NOT NULL IDENTITY(1,1),
	NumeroProcesso VARCHAR(12) NOT NULL,
	ValorCausa decimal(18,2) NOT NULL,
	Escritorio varchar(50) NOT NULL,
	NomeReclamante varchar(100) NOT NULL,
	DataInclusao Datetime NOT NULL,
	DataEdicao Datetime,
	FlgAtivo bit NOT NULL,
	FlgAprovado bit NOT NULL,
	CONSTRAINT CHK_ValorCausa CHECK (ValorCausa >=30000),
	CONSTRAINT PK_Aprovacao PRIMARY KEY(ID),
	CONSTRAINT UC_NumeroProcesso UNIQUE (NumeroProcesso)
)

ALTER TABLE TBL_PROCESSOS
ADD DataCompra Datetime;






