/*  INSERT ROL */

INSERT INTO Rol(
    [Name]            ,
    [Description]    ,
    [IsDeleted]       ,
    [IsActive]        ,
    [AuditCreateUser] ,
    [AuditCreateDate] ,
    [AuditUpdateUser] ,
    [AuditUpdateDate] ) 
    VALUES(
    'Admin',
    'Administrador de Plataforma',
    0,
    1,
    'System',
    '18/02/2024',
    NULL,
    NULL
    );
    GO;

    /*  INSERT USER */

INSERT INTO [User](
    [Name],
    [LastName]        ,
    [Adress]          ,
    [PhoneNumber]     ,
    [Email]           ,
    [Token]           ,
    [PlanId]          ,
    [RolId]           ,
    [IsDeleted]       ,
    [IsActive]        ,
    [AuditCreateUser] ,
    [AuditCreateDate] ,
    [AuditUpdateUser] ,
    [AuditUpdateDate] 
VALUES('CyanAdmin',NULL,NULL,NULL,'Cyan')