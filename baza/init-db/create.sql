CREATE TABLE users (
    id_user SERIAL PRIMARY KEY,
    email VARCHAR(255) UNIQUE NOT NULL,
    name VARCHAR(100) NOT NULL,
    password VARCHAR (255) NOT NULL,
    role VARCHAR (50) NOT NULL
);

CREATE TABLE orders (
    id_order SERIAL PRIMARY KEY,
    user_id INTEGER REFERENCES users (id_user),
    city VARCHAR(255) NOT NULL,
    street_name_nr VARCHAR(255) NOT NULL,
    flat_nr INTEGER,
    pickup_date timestamp NOT NULL,
    details VARCHAR (255)
);

CREATE TABLE received_orders (
    id_received_order  SERIAL PRIMARY KEY,
    order_id INTEGER REFERENCES orders (id_order),
    user_id INTEGER REFERENCES users (id_user),
    status VARCHAR (255) NOT NULL,
    value FLOAT
);
