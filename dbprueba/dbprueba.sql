create table articulo (
  id bigint auto_increment primary key,
  nombre varchar(50) not null unique,
  categoria bigint,
  precio decimal(10,2)
);


create table categoria (
  id bigint auto_increment primary key,
  nombre varchar(50) not null unique
);

