create table tb_pacientes
(
	idPacientes int identity not null primary key,
	idTipoDocumento int foreign key references tb_tipoDeDocumento(idTipoDocumento),
	numeroDeDocumento int not null,
	nombres varchar(50) not null,
	apellidos varchar(50) not null,
	correoElectronico nvarchar(100) not null,
	telefono varchar(10) not null,
	fechaDeNacimiento datetime,
	idAfiliacion int foreign key references tb_estadoAfiliacion(idAfiliacion)
);


create table tb_tipoDeDocumento
(
	idTipoDocumento int identity not null primary key,
	nombreTipoDocumento varchar(50) not null
);

insert into tb_tipoDeDocumento("nombreTipoDocumento") values ('PA_Pasaporte');

insert into tb_estadoAfiliacion("estadoAfiliacion") values ('Inactivo');

insert into tb_pacientes
	("idTipoDocumento","numeroDeDocumento","nombres","apellidos","correoElectronico","telefono","fechaDeNacimiento","idAfiliacion") 
	values 
	('1','1001205187','Luis Fernando','Gomez Meza','lfgm@gmail.com','3214859300','14-04-2001','1');

create table tb_estadoAfiliacion
(
	idAfiliacion int identity not null primary key,
	estadoAfiliacion varchar(20) not null
);