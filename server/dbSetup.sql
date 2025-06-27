CREATE TABLE IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255) COMMENT 'User Name',
    email VARCHAR(255) UNIQUE COMMENT 'User Email',
    picture VARCHAR(255) COMMENT 'User Picture',
    cover_img VARCHAR(1000)
) default charset utf8mb4 COMMENT '';

SELECT accounts.id FROM accounts WHERE id = @profileId;
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

SELECT keeps.*, accounts.*
FROM keeps
    INNER JOIN accounts ON accounts.id = keeps.creator_id
WHERE
    keeps.id = @keepsId;

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

UPDATE keeps
SET
    name = @Name,
    description = @Description,
    img = @Img
WHERE
    id = @Id
LIMIT 1;

DELETE FROM keeps WHERE keeps.id = @Id;

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

INSERT INTO
    vaults (
        id,
        created_at,
        updated_at,
        name,
        description,
        img,
        is_private,
        creator_id
    )
VALUES (
        @Id,
        @CreatedAt,
        @UpdatedAt,
        @Name,
        @Description,
        @Img,
        @IsPrivate,
        @CreatorId
    );

SELECT vaults.*, accounts.*
FROM vaults
    INNER JOIN accounts ON vaults.creator_id = accounts.id
WHERE
    vaults.id = LAST_INSERT_ID();

SELECT vaults.*, accounts.*
FROM vaults
    INNER JOIN accounts ON accounts.id = vaults.creator_id
WHERE
    vaults.id = @vaultsId;

UPDATE vaults
SET
    name = @Name,
    description = @Description,
    img = @Img
WHERE
    id = @Id
LIMIT 1;

DELETE FROM vaults WHERE vaults.id = @VaultId;

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

INSERT INTO
    vault_keeps (keep_id, vault_id, creator_id)
VALUES (
        12,
        4,
        '67e592b83f3192a0a5480d98'
    );

SELECT keep_id, vault_id, vault_keeps.creator_id
FROM
    vault_keeps
    INNER JOIN keeps ON keeps.id = vault_keeps.keep_id
    INNER JOIN vaults ON vaults.id = vault_keeps.vault_id
    INNER JOIN accounts ON accounts.id = vault_keeps.creator_id
WHERE
    keeps.id = @KeepId
    AND vaults.id = @VaultId
    AND accounts.id = @CreatorId;

SELECT keep_id, vault_id, vault_keeps.creator_id
FROM
    vault_keeps
    INNER JOIN keeps ON keeps.id = vault_keeps.keep_id
    INNER JOIN vaults ON vaults.id = vault_keeps.vault_id
    INNER JOIN accounts ON accounts.id = vault_keeps.creator_id
WHERE
    vault_id = @VaultId;

SELECT keep_id, vault_id, vault_keeps.creator_id
FROM
    vault_keeps
    INNER JOIN keeps ON keeps.id = vault_keeps.keep_id
    INNER JOIN vaults ON vaults.id = vault_keeps.vault_id
    INNER JOIN accounts ON accounts.id = vault_keeps.creator_id
WHERE
    vault_id = @VaultId;

SELECT keep_id, vault_id, vault_keeps.creator_id
FROM
    vault_keeps
    INNER JOIN keeps ON keeps.id = vault_keeps.keep_id
    INNER JOIN accounts ON accounts.id = vault_keeps.creator_id
WHERE
    vault_id = 12;

DELETE FROM vault_keeps WHERE vault_keeps.keep_id = @VaultKeepId;