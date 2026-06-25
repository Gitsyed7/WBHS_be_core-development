
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'api_integration')
BEGIN
    EXEC('CREATE SCHEMA api_integration');
END

CREATE TABLE api_integration.api_source ( 
    id INT IDENTITY(1,1) NOT NULL, 
    department_code VARCHAR(50) NOT NULL, 
    department_name VARCHAR(200) NOT NULL, 
    api_type VARCHAR(20) NOT NULL, 
    endpoint_url VARCHAR(MAX) NOT NULL, 
    auth_type VARCHAR(20) NOT NULL DEFAULT 'API_KEY', 
    auth_header_name VARCHAR(100) NULL, 
    is_active BIT NOT NULL DEFAULT 1, 
    sync_cron VARCHAR(100) NOT NULL DEFAULT '0 2 * * *', 
    timeout_seconds INT NOT NULL DEFAULT 30, 
    max_retry_count INT NOT NULL DEFAULT 3, 
    created_at DATETIME NOT NULL DEFAULT GETDATE(), 
    updated_at DATETIME NOT NULL DEFAULT GETDATE(), 
    api_key VARCHAR(MAX) NULL, 
    api_secret_encrypted VARCHAR(MAX) NULL, 
    auth_credential VARCHAR(MAX) NULL, 
    uses_name_mapping BIT NOT NULL DEFAULT 0, 

    CONSTRAINT api_source_pkey PRIMARY KEY (id),

    CONSTRAINT api_source_api_type_check 
        CHECK (api_type IN ('OFFICE', 'SERVICE', 'USER', 'ACK', 'CALLBACK')), 

    CONSTRAINT api_source_auth_type_check 
        CHECK (auth_type IN ('API_KEY', 'BEARER', 'BASIC', 'NONE', 'HMAC')), 

    CONSTRAINT uq_api_source_dept_type 
        UNIQUE (department_code, api_type)
);

CREATE INDEX idx_api_source_department 
ON api_integration.api_source (department_code);

CREATE TRIGGER trg_api_source_updated_at
ON api_integration.api_source
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE t
    SET updated_at = GETDATE()
    FROM api_integration.api_source t
    INNER JOIN inserted i ON t.id = i.id;
END;

