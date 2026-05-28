CREATE DATABASE mecanico;
GO
USE mecanico;
GO

CREATE TABLE TipoServicio (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    preciobase DECIMAL(10,2) NOT NULL
);

CREATE TABLE cliente (
    id INT IDENTITY(1,1) PRIMARY KEY,
    paterno VARCHAR(50) NOT NULL,
    materno VARCHAR(50),
    nombres VARCHAR(100) NOT NULL,
    correo VARCHAR(100),
    telefono VARCHAR(20)
);

CREATE TABLE vehiculo (
    id INT IDENTITY(1,1) PRIMARY KEY,
    placa VARCHAR(20) NOT NULL,
    marca VARCHAR(50) NOT NULL,
    modelo VARCHAR(50) NOT NULL,
    anio INT,
    clienteid INT NOT NULL,
    CONSTRAINT FK_vehiculo_cliente FOREIGN KEY (clienteid) REFERENCES cliente(id)
);

CREATE TABLE ordenservicio (
    id INT IDENTITY(1,1) PRIMARY KEY,
    fechaingreso DATE NOT NULL,
    descripcionproblema VARCHAR(500),
    costoestimado DECIMAL(10,2),
    estado VARCHAR(20),
    vehiculoid INT NOT NULL,
    tiposervicioid INT NOT NULL,
    CONSTRAINT FK_ordenservicio_vehiculo FOREIGN KEY (vehiculoid) REFERENCES vehiculo(id),
    CONSTRAINT FK_ordenservicio_tiposervicio FOREIGN KEY (tiposervicioid) REFERENCES TipoServicio(id)
);

INSERT INTO TipoServicio(nombre, preciobase) VALUES
('Cambio de aceite', 150.00),
('Alineación y balanceo', 200.00),
('Revisión de frenos', 180.00);

INSERT INTO cliente(paterno, materno, nombres, correo, telefono) VALUES
('García', 'López', 'Juan', 'juan@mail.com', '999111222'),
('Martínez', 'Rojas', 'María', 'maria@mail.com', '999333444'),
('Pérez', null, 'Carlos', 'carlos@mail.com', '999555666');

INSERT INTO vehiculo(placa, marca, modelo, anio, clienteid) VALUES
('ABC-123', 'Toyota', 'Corolla', 2020, 1),
('DEF-456', 'Honda', 'Civic', 2019, 1),
('GHI-789', 'Nissan', 'Sentra', 2021, 2);

INSERT INTO ordenservicio(fechaingreso, descripcionproblema, costoestimado, estado, vehiculoid, tiposervicioid) VALUES
('2026-05-01', 'Cambio de aceite y filtro', 150.00, 'Completado', 1, 1),
('2026-05-15', 'Vibración al acelerar', 200.00, 'En proceso', 2, 2),
('2026-05-20', 'Ruido al frenar', 180.00, 'Pendiente', 3, 3);
