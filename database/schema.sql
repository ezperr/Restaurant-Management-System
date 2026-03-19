CREATE DATABASE restaurant;
USE restaurant;

-- Таблица столиков
CREATE TABLE tables (
    idtables INT PRIMARY KEY AUTO_INCREMENT,
    number VARCHAR(45) NOT NULL,
    status VARCHAR(45) DEFAULT 'free',
    seats INT NOT NULL
);

-- Таблица меню (исправлена опечатка description)
CREATE TABLE menu (
    idmenu INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(45) NOT NULL,
    price DECIMAL(10,2) NOT NULL,
    description VARCHAR(200) DEFAULT NULL
);

-- Таблица заказов С total
CREATE TABLE orders (
    idorders INT PRIMARY KEY AUTO_INCREMENT,
    table_id INT DEFAULT NULL,
    status VARCHAR(20) DEFAULT 'new',
    total DECIMAL(10,2) DEFAULT '0.00',  -- ← Считаем в C#
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (table_id) REFERENCES tables(idtables)
);

-- Таблица позиций заказа
CREATE TABLE order_items (
    idorder_items INT PRIMARY KEY AUTO_INCREMENT,
    order_id INT NOT NULL,
    menu_id INT NOT NULL,
    quantity INT NOT NULL,
    FOREIGN KEY (order_id) REFERENCES orders(idorders) ON DELETE CASCADE,
    FOREIGN KEY (menu_id) REFERENCES menu(idmenu)
);