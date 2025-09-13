INSERT INTO Products (n_prod, unit_price, active) VALUES
('Laptop', 1200.00, 1),
('Mouse', 25.50, 1),
('Keyboard', 75.00, 1),
('Monitor', 300.00, 1),
('USB Drive', 15.00, 1);

INSERT INTO paym_meth (id_pay_meth, n_pay_meth) VALUES
(1,'Credit Card'),
(2, 'Debit Card'),
(3, 'Cash'),
(4, 'Bank Transfer');


INSERT INTO Bills (date_b, client, Cancelled, id_pay_meth) VALUES
('2025-09-01', 'Juan Perez', 0, 1),
('2025-09-02', 'Maria Lopez', 0, 2),
('2025-09-03', 'Carlos Gomez', 0, 3),
('2025-09-04', 'Ana Garcia', 1, 4),
('2025-09-05', 'Pedro Martinez', 0, 1);

INSERT INTO Details (id_product, amount) VALUES
(1, 1),   -- Bill 1: 1 Laptop
(2, 2),   -- Bill 1: 2 Mice
(3, 1),   -- Bill 2: 1 Keyboard
(4, 1),   -- Bill 2: 1 Monitor
(5, 3),   -- Bill 3: 3 USB Drives
(1, 1),   -- Bill 4 (Cancelled): 1 Laptop
(2, 1),   -- Bill 4 (Cancelled): 1 Mouse
(3, 2),   -- Bill 5: 2 Keyboards
(5, 1);   -- Bill 5: 1 USB Drive


UPDATE Bills SET id_detail = 1 WHERE id_bill = 1;
UPDATE Bills SET id_detail = 3 WHERE id_bill = 2;
UPDATE Bills SET id_detail = 5 WHERE id_bill = 3;
UPDATE Bills SET id_detail = 6 WHERE id_bill = 4;
UPDATE Bills SET id_detail = 8 WHERE id_bill = 5;

