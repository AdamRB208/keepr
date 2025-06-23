CREATE TABLE IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255) COMMENT 'User Name',
    email VARCHAR(255) UNIQUE COMMENT 'User Email',
    picture VARCHAR(255) COMMENT 'User Picture',
    cover_img VARCHAR(1000)
) default charset utf8mb4 COMMENT '';

ALTER table accounts ADD COLUMN cover_img VARCHAR(1000);

CREATE TABLE keeps (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    name VARCHAR(255) NOT NULL,
    description VARCHAR(1000) NOT NULL,
    img VARCHAR(1000) NOT NULL,
    views INT,
    creator_id VARCHAR(255) NOT NULL,
    FOREIGN KEY (creator_id) REFERENCES accounts (id) ON DELETE CASCADE
);

SELECT keeps.*, accounts.*
FROM keeps
    INNER JOIN accounts ON keeps.creator_id = accounts.id
WHERE
    keeps.id = LAST_INSERT_ID();

SELECT keeps.*, accounts.*
FROM keeps
    INNER JOIN accounts on accounts.id = keeps.creator_id;

INSERT INTO
    keeps (
        id,
        created_at,
        updated_at,
        name,
        description,
        img,
        views,
        creator_id
    )
VALUES (
        @Id,
        @CreatedAt,
        @UpdatedAt,
        @Name,
        @Description,
        @Img,
        @Views,
        @CreatorId
    );

SELECT keeps.*, accounts.id
FROM keeps
    INNER JOIN accounts ON accounts.id = keeps.creator_id
WHERE
    keeps.creator_id = @creator_id

CREATE TABLE vaults (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    name VARCHAR(255) NOT NULL,
    description VARCHAR(1000) NOT NULL,
    img VARCHAR(1000) NOT NULL,
    is_private BOOLEAN NOT NULL DEFAULT false,
    creator_id VARCHAR(255) NOT NULL,
    FOREIGN KEY (creator_id) REFERENCES accounts (id) ON DELETE CASCADE
);

CREATE TABLE vault_keeps (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    keep_id INT NOT NULL,
    vault_id INT NOT NULL,
    creator_id VARCHAR(255) NOT NULL,
    FOREIGN KEY (keep_id) REFERENCES keeps (id) ON DELETE CASCADE,
    FOREIGN KEY (vault_id) REFERENCES vaults (id) ON DELETE CASCADE,
    FOREIGN KEY (creator_id) REFERENCES accounts (id) ON DELETE CASCADE,
    UNIQUE (keep_id, vault_id)
);