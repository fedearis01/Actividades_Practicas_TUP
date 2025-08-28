-- Inserts para la tabla paym_meth
-- El ID no es IDENTITY, por lo tanto se debe insertar manualmente
INSERT INTO paym_meth (id_pay_meth, n_pay_meth)
VALUES 
    (1, 'Tarjeta de Credito'),
    (2, 'Transferencia'),
    (3, 'Efectivo'),
    (4, 'PayPal'),
    (5, 'Criptomoneda'),
    (6, 'Cheque'),
    (7, 'Debito')

---

-- Inserts para la tabla Products
-- El campo 'active' tiene un valor por defecto de 1
INSERT INTO Products (n_prod, unit_price,active)
VALUES 
    ('Mouse Logitech G502', 75.99,1),
    ('Teclado Mecanico Redragon', 49.50,1),
    ('Monitor Samsung 27"', 250.00,1),
    ('Auriculares HyperX Cloud II', 89.90,1),
    ('Webcam Logitech C920', 65.00,1),
    ('Disco Duro SSD Kingston 1TB', 99.99,1),
    ('Tarjeta Grafica NVIDIA RTX 3060', 450.00,1),
    ('Procesador AMD Ryzen 5', 180.50,1),
    ('Memoria RAM Corsair 16GB', 75.25,1),
    ('Fuente de Poder EVGA 600W', 60.00,1);

---

-- Inserts para la tabla Bills
-- El campo 'cancelled' tiene un valor por defecto de 0
-- La fecha se formatea como DMY
INSERT INTO Bills (date_b, client, id_pay_meth,Cancelled)
VALUES 
    (CONVERT(DATETIME, '28/08/2025', 103), 'Juan Perez', 1,0),
    (CONVERT(DATETIME, '27/08/2025', 103), 'Maria Gomez', 3,0),
    (CONVERT(DATETIME, '26/08/2025', 103), 'Carlos Ruiz', 2,0),
    (CONVERT(DATETIME, '25/08/2025', 103), 'Ana Torres', 4,0),
    (CONVERT(DATETIME, '24/08/2025', 103), 'Pedro Lopez', 5,0),
    (CONVERT(DATETIME, '23/08/2025', 103), 'Laura Diaz', 6,0),
    (CONVERT(DATETIME, '22/08/2025', 103), 'Roberto Sanchez', 7,0),
    (CONVERT(DATETIME, '21/08/2025', 103), 'Sofia Ramirez', 5,0),
    (CONVERT(DATETIME, '20/08/2025', 103), 'Diego Fernandez', 5,0),
    (CONVERT(DATETIME, '19/08/2025', 103), 'Elena Navarro', 3,0);

---

-- Inserts para la tabla Details
-- El campo 'id_detail' es IDENTITY
INSERT INTO Details (id_product, amount, id_bill)
VALUES 
    (1, 10, 1),   -- Detalle para la factura 1
    (2, 34, 1),   -- Otro detalle para la factura 1
    (3, 50, 2),   -- Detalle para la factura 2
    (4, 35, 3),   -- Detalle para la factura 3
    (5, 20, 4),   -- Detalle para la factura 4
    (6, 100, 5),   -- Detalle para la factura 5
    (7, 40, 6),   -- Detalle para la factura 6
    (8, 60, 7),   -- Detalle para la factura 7
    (9, 75, 8),   -- Detalle para la factura 8
    (10, 30, 9),  -- Detalle para la factura 9
	(4,2,10)