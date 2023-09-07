\c porphum_web
BEGIN;

DROP TABLE IF EXISTS user_roles_map;
DROP TABLE IF EXISTS roles;
DROP TABLE IF EXISTS users;

CREATE TABLE users(
    Id BIGSERIAL PRIMARY KEY,
    Login VARCHAR(60) NOT NULL,
    Password VARCHAR(60) NOT NULL
);

CREATE TABLE roles(
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(40) NOT NULL
);

CREATE TABLE user_roles_map(
    user_id BIGINT NOT NULL,
    role_id INT NOT NULL,
    PRIMARY KEY(user_id, role_id),

    FOREIGN KEY(user_id) REFERENCES users(Id) ON DELETE CASCADE,
    FOREIGN KEY(role_id) REFERENCES roles(Id) ON DELETE CASCADE
);

UPDATE db_version SET version = 3 WHERE TRUE; 

INSERT INTO roles(Id, Name) VALUES
(1, 'Admin'),
(2, 'Guest'),
(3, 'Employee');

INSERT INTO users(Id, Login, Password) VALUES
(1, 'admin', 'admin');

INSERT INTO user_roles_map(user_id, role_id) VALUES
(1,1),
(1,3);

COMMIT;