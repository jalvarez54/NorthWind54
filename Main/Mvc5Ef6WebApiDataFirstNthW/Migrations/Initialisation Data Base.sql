DECLARE @CurrentMigration [nvarchar](max)

IF object_id('[dbo].[__MigrationHistory]') IS NOT NULL
    SELECT @CurrentMigration =
        (SELECT TOP (1) 
        [Project1].[MigrationId] AS [MigrationId]
        FROM ( SELECT 
        [Extent1].[MigrationId] AS [MigrationId]
        FROM [dbo].[__MigrationHistory] AS [Extent1]
        WHERE [Extent1].[ContextKey] = N'Mvc5Ef6WebApiDataFirstNthW.Migrations.Configuration'
        )  AS [Project1]
        ORDER BY [Project1].[MigrationId] DESC)

IF @CurrentMigration IS NULL
    SET @CurrentMigration = '0'

IF @CurrentMigration < '201402101412074_Initialisation'
BEGIN
    CREATE TABLE [dbo].[AspNetRoles] (
        [Id] [nvarchar](128) NOT NULL,
        [Name] [nvarchar](max) NOT NULL,
        CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY ([Id])
    )
    CREATE TABLE [dbo].[AspNetUsers] (
        [Id] [nvarchar](128) NOT NULL,
        [UserName] [nvarchar](max),
        [PasswordHash] [nvarchar](max),
        [SecurityStamp] [nvarchar](max),
        [FirstName] [nvarchar](max),
        [LastName] [nvarchar](max),
        [Email] [nvarchar](max),
        [Discriminator] [nvarchar](128) NOT NULL,
        CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY ([Id])
    )
    CREATE TABLE [dbo].[AspNetUserClaims] (
        [Id] [int] NOT NULL IDENTITY,
        [ClaimType] [nvarchar](max),
        [ClaimValue] [nvarchar](max),
        [User_Id] [nvarchar](128) NOT NULL,
        CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY ([Id])
    )
    CREATE INDEX [IX_User_Id] ON [dbo].[AspNetUserClaims]([User_Id])
    CREATE TABLE [dbo].[AspNetUserLogins] (
        [UserId] [nvarchar](128) NOT NULL,
        [LoginProvider] [nvarchar](128) NOT NULL,
        [ProviderKey] [nvarchar](128) NOT NULL,
        CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY ([UserId], [LoginProvider], [ProviderKey])
    )
    CREATE INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]([UserId])
    CREATE TABLE [dbo].[AspNetUserRoles] (
        [UserId] [nvarchar](128) NOT NULL,
        [RoleId] [nvarchar](128) NOT NULL,
        CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId])
    )
    CREATE INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]([RoleId])
    CREATE INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]([UserId])
    ALTER TABLE [dbo].[AspNetUserClaims] ADD CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
    ALTER TABLE [dbo].[AspNetUserLogins] ADD CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
    ALTER TABLE [dbo].[AspNetUserRoles] ADD CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE
    ALTER TABLE [dbo].[AspNetUserRoles] ADD CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
    CREATE TABLE [dbo].[__MigrationHistory] (
        [MigrationId] [nvarchar](150) NOT NULL,
        [ContextKey] [nvarchar](300) NOT NULL,
        [Model] [varbinary](max) NOT NULL,
        [ProductVersion] [nvarchar](32) NOT NULL,
        CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
    )
    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'201402101412074_Initialisation', N'Mvc5Ef6WebApiDataFirstNthW.Migrations.Configuration',  0x1F8B0800000000000400DD5CDB6EDC36107D2FD07F10F4941488653B689106BB099CB5DD1A8DED209BCB63404BDC3551895245AE6B7F5B1FFA49FD8592BA52E245D44A7BCB4BE0A58633C3E1E1901C1DE5BF7FFE9DBC7D8C42E701A604C578EA9E1C1DBB0EC47E1C20BC9CBA2BBA78F1CA7DFBE6C71F261741F4E87C29E55E7239D61393A97B4F69F2DAF3887F0F23408E22E4A7318917F4C88F230F04B1777A7CFCAB7772E241A6C265BA1C67F27185298A60F683FD9CC5D887095D81F03A0E60488A76F6649E69756E400449027C3875AF1FFC9F2F16BF7C857767093A07145CA294D01B7AFFF528EFEC3A672102CCB1390C17AE03308E29A0CCEDD79F099CD334C6CB79C21A40F8E929814C6E0142028BE1BCAEC56D47767CCA47E6D51DD78A8C5B8D998DFA8245873E71F7B2914FDDAB00664D1FE3108A924CF60FF8D468604D1FD238812993868BAABFEB78CD7E5EBB63D54DE8C35D6081A4298383EB5C83C7F7102FE93D03CAE92BD7B9448F30285B8A287EC688A18775A2E98AFDBC598521B80B61F5DC33DAE4FF1AACB23F875B9D7875788D413F4B9210F9D99432E4A4AEF30E1058F8C6A075544E4AF6D038AC1CA25B189B6CFA3DD895E58B08A0706F26539CAC590850B4FD657485E9CB53C578840C35A7710A7F8318A680C2E003A014A6B876BE2BE4D9C0B8B111C26E61E90B08571B3075031ED0328B47CB68BE0A3FC2307B48EE51A258899967DF72D1CB348E78CA544C7F26F16D1EAF529F0F21368A7D02E912D21190F73DE76E3EBE91328DD9D00740C8DF711AFC0EC8FDC68DCDA1BF4AD9ECCD2988922D623D431F1917ED258C3BD05E2E0A5B57DFC74B84BB5DCDC48CAED612465705B1BEAE7265DD9E7229A3A39580D1CF5A4AE5E65AF9231BFA3A4984779613895234B3C19A1F50C02360D1A314669EF44F55A567DB4E57AD616EDB7C23661B373E6C4BEDB5724D5BAA62810F5E12EB5E897AAC086E629D5D7857D02EFDDD1DACB249B14AB3B9A421CD66FF9840554BA9303518FC3D36834E2F7B23FF8C90D847997BBADDE09BE25C798103C76E91AA6FB3F936E35CAF428AF81D98354FDD9FA4C0769AA97647CDA5B965E1C46DAFC55B7C0E4348A173E6E7259919203E086424B2F805CD16B67C61CA6D8170C62697A600612AAF75847D9480D06A1CADDE96A775EE5D65A7FDE41C261073A356F365E38036AF7995AD56E8BA2235F10418DAA3B35EDE36A851AC753568F284B11E34E554A130A232B05FC89486B165604A7365635FBD89EE0A97D6495391DD3784CBC3CF98D2307681CB83CD97C255DE0633AA2A961A3479B9734D68AACA07DBC6A636A0F9A1894D0265530053B96E7F7EC71FC2472A8594779C43DAAC0BD48730E59E2005ACA9440A9B49A330313DD47669ECA5ACACDB18351647C11E6ABB625927CB965261920D0E17677141D87C636D83D0FA6C5C8D511D35295F589F86358A259D0DD833F19ED112AE57E660690E6A3D8E6A9A111548B08C947C3813D42A558D11201B34694E0C3DCE0CE305681748128BCCE648E9F6B03EBB9866506546B50C9662DF1A215AE53DBDDA726AA6829753154A4A83A7E1344CAE419220BC14380E458B33CF090EB317F3FE0C8228D7E1F9444124A8BCAD2CD138054BD87ACA4C334FB377D59C57710778C567164492589F0DB63429EEB3F20C965B4529CDFFCE7B74D23D9A7BB47CE22B545EB20147FCD898BD62554041DDDDE11414108254F1826D1687AB08EB4FB1FADEF96B32B17FDE226B98782DFFA553AA143CE928D59C09AB796AAE8F71E7AB4DAB587FCAD4DD373365028543542234DBEBAA3919A2AABAD55E53C1B110D5144D4A1D6CAD0628BB7E64AFEE15141751D339227E8A2284018BFF26C0D901A52BC2FFBE5D3CB3CF017C10CF0F0451DC968C82BAD55E53F385B8A8ADF9C45E63EBADB7A8B2F568EBA8E80786FDC382B4069BF7B7AD2EC0117687E258B6B9195490B57A4FA346C766D6B540C2129508CD3D7515342B4959D1BE97B0286EC99B83858209D11B161A1DA684DD8686AE7AA8D7D2E21D344E0066E6855E67834CD0C8FF7A66C69E0065933702353DA0374CFADD0CC64149F9B644D4A27B83B2F9796CDE873B3683A2503028DF173A7AE7745E0C9092B9A9282087D26A47C854A8DF1A081EACED9CF6F5C5DADB95DEAF76B543068054F4688B54F0AB8A1FAD22C7A42838747FDD2155207211D72933193B803E110AA3232E7034FF2B9C8588C5B016B806182D20A19FE23F219EBAA7C727A7AD2F42D6F83AC3232408F7F9130DFC0052FF1EA432CD67C01718A5D26711787CBE0922FE01C7A9BEA775C46A5D46F320854AD6F2208DD2272C83B4B5BF4A19A4ACF1A1C9204DAD0BD720C81CD297298827D0CE6F4F7AAE10E963944153237F7032485DB5816F7F8EBF7B0EF768395649D11E4DBB8281BD4D181C0C6F79B4803769C923C77A54A6EC6EF8570602C150A6EE606AD74EB8AF87C5DFB2E7BBE6A48C5D504FF5C48281BCC64100D3D46836CE15FC9E79ABFB94C2768DAF5D24306B7CED4DFEEAC93FDD27801544CA61FCD7838398EECD981A639A72E5E8206BD50ACBEB9BC42CD2BC295055D3BA78B9798D70EA06773103417E743C23C90DA46ADAA0CE588E5EADB1A226AD35A62693998C15C8345A2C64CC66D5E4B86EF6AF1DF9D76C5B4D88EDA4085B3184CD96D5B3BB4B1AB19664D88F2F6C261F1F024F589C619966D787F16A24CF1E0A2378382EB61D8A0D727E8707A39137356F063742EA95DF63B19D52F8BFCCD87E4DD0B256C1D93E18FA8D3DB292B9C28BB8DCAB5B1E9522AD0ACA35A420601BE8594AD102F8943DF62121D9E7DD059BE822BA83C115BE5DD16445D990617417362A7A7CCB37D9CF98CB4D9F27B749F681F41843606E223604788BDFAD5018547E5F2A4A3D1A15FC2C51D4A9F95C525EAF5E3E559A6E626CA9A8085F7504FA04A32464CAC82D9E8307A8F7AD3B86CD884DCE1158A62022858EBA3FFBC9E017448F6FFE07106D46548D4F0000 , N'6.0.2-21211')
END

