
CREATE TABLE api_integration.api_source ( 
    id INT IDENTITY(1,1) NOT NULL,
    api_type VARCHAR(20) NOT NULL, 
    endpoint_url VARCHAR(MAX) NOT NULL, 
    auth_type VARCHAR(20) NOT NULL DEFAULT 'API_KEY', 
    auth_header_name VARCHAR(100) NULL, 
    is_active BIT NOT NULL DEFAULT 1,     
    timeout_seconds INT NOT NULL DEFAULT 15, 
    max_retry_count INT NOT NULL DEFAULT 3, 
    created_at DATETIME NOT NULL DEFAULT GETDATE(), 
    updated_at DATETIME NOT NULL DEFAULT GETDATE(), 
    api_key VARCHAR(MAX) NULL, 
    api_secret_encrypted VARCHAR(MAX) NULL, 
    auth_credential VARCHAR(MAX) NULL,

    CONSTRAINT api_source_pkey PRIMARY KEY (id),

    CONSTRAINT api_source_api_type_check 
        CHECK (api_type IN ('OFFICE', 'SERVICE', 'USER', 'ACK', 'CALLBACK')), 

    CONSTRAINT api_source_auth_type_check 
        CHECK (auth_type IN ('API_KEY', 'BEARER', 'BASIC', 'NONE', 'HMAC')), 

   
);