create database ventas 

/*CLIENTE*/
create table if not exists cliente (
    id_cliente int(6) not null auto_increment,
    dpi varchar(16) not null,
    nit varchar(20) not null,
    nombre varchar(30) not null,
    apellido varchar(30) not null,
    telefono int(8) not null,
    correo varchar(35) not null,
    direccion varchar(35)not null,
    primary key (id_cliente),
    key (id_cliente)
);
/*EMPLEADO*/
create table if not exists empleado (
    id_empleado int(6) not null auto_increment,
    dpi varchar(16) not null,
    nit varchar(20) not null,
    nombre varchar(30) not null,
    apellido varchar(30) not null,
    correo varchar(45) not null,
    telefono int(8) not null,
    direccion varchar(45) not null,
    primary key (id_empleado),
    key (id_empleado)
);
/*PRODUCTO*/
create table if not exists producto (
    id_producto int(6) not null auto_increment,
    Nombre varchar(40) not null,
    precio double(12,2)not null,
    cantidad int(8)not null, 
    descripcion varchar(30)not null, 
    primary key (id_producto),
    key (id_producto)
);

/*ENCABEZADO_FACTURA*/
create table if not exists encabezado_factura (
    id_encabezado_factura int(6) not null,
    id_cliente int(6) not null,
    id_empleado int(6) not null,
    no_serie varchar(10)not null,
    fecha  datetime not null,
    forma_pago int(1)not null,
    total_factura double(12,2) not null,
    tipo_doc int(1)not null,
    primary key (id_encabezado_factura),
    key (id_encabezado_factura)
);

/*DETALLE_FACTURA */
create table if not exists detalle_factura (
    id_detalle_factura int(6)not null,
    cod_linea int(6)not null,
    id_producto int(6) not null,
    cantidad double(12,2)not null,
    subtotal double(12,2) not null,
    primary key (id_detalle_factura)
);

/*PROVEEDOR*/
create table if not exists proveedor (
    id_proveedor int(6) not null auto_increment,
    id_producto int(6) ,
    razon_social varchar(100) not null,
    representante_legal varchar(30) not null,
    nit varchar(20)not null,
    telefono int(8) not null,
    correo varchar(40) not null,
    primary key (id_proveedor),
    key (id_proveedor)
);

create table if not exists venta (
    id_venta int(6) not null auto_increment,
	id_cliente int(6) ,
    id_empleado int(6),
    id_producto int(6),
    id_encabezado_factura int(6),
    fecha datetime not null,
    primary key (id_venta),
    key (id_venta)
);

drop  table venta
alter table venta add constraint fk_cliente foreign key(id_cliente) references cliente(id_cliente);
alter table venta add constraint fk_empleado foreign key(id_empleado) references empleado(id_empleado);
alter table venta add constraint fk_producto foreign key(id_producto) references producto(id_producto);
alter table proveedor add constraint fk_proveedor_producto foreign key(id_producto) references producto(id_producto);
alter table venta add constraint fk_id_encabesado_factura foreign key(id_encabezado_factura) references encabezado_factura(id_encabezado_factura);
alter table detalle_factura add constraint fk_detalle_factura foreign key(id_detalle_factura) references encabezado_factura(id_encabezado_factura);
