CREATE TABLE users (
    id_user SERIAL PRIMARY KEY,
    email VARCHAR(255) UNIQUE NOT NULL,
    name VARCHAR(100) NOT NULL,
    password VARCHAR (255) NOT NULL,
    phone varchar (50),
    role VARCHAR (50) NOT NULL,
    balance DECIMAL(10, 2) NOT NULL DEFAULT 0.00,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW()
);

CREATE TABLE orders (
    id_order SERIAL PRIMARY KEY,
    user_id INTEGER NOT NULL REFERENCES users (id_user),
    courier_id INTEGER REFERENCES users (id_user),
    city VARCHAR(255) NOT NULL,
    street_address VARCHAR(255) NOT NULL,
    flat_nr VARCHAR (20),
    estimated_bottles INT NOT NULL CHECK (estimated_bottles > 0),
    status VARCHAR (50) NOT NULL DEFAULT 'OPEN',
    pickup_date DATE NOT NULL,
    pickup_time_slot VARCHAR(20) NOT NULL,
    user_payout DECIMAL(10, 2) NULL,
    courier_payout DECIMAL(10, 2) NULL,
    app_fee DECIMAL(10, 2) NULL,
    details TEXT,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW()
);
