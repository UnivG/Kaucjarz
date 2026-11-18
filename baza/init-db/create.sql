CREATE TABLE users (
    id SERIAL PRIMARY KEY,
    email VARCHAR(255) UNIQUE NOT NULL,
    name VARCHAR(100) NOT NULL,
    password varchar 255
);
INSERT INTO USERS VALUES(1,'test@test.com','testuser');
