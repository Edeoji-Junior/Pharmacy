INSERT INTO Countries VALUES ('Nigeria',GETDATE(),1,0,1);

INSERT INTO States VALUES (1,'Abia',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Akwa-Ibom',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Anambra',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Bauchi',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Bayelsa',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Benue',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Borno',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Cross River',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Delta',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Ebonyi',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Edo',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Ekiti',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Enugu',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Gombe',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Imo',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Jigawa',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Kaduna',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Kano',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Katsina',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Kebbi',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Kogi',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Kwara',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Lagos',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Nasarawa',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Niger',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Ogun',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Ondo',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Osun',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Oyo',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Plateau',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Rivers',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Sokoto',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Taraba',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Yobe',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Zamfara',GETDATE(),1,0,1);
INSERT INTO States VALUES (1,'Abuja',GETDATE(),1,0,1);



INSERT INTO AspNetRoles VALUES ( NEWID(),'SuperAdmin','SUPERADMIN',NEWID() );
INSERT INTO AspNetRoles VALUES ( NEWID(),'User','USER',NEWID());  
INSERT INTO AspNetRoles VALUES ( NEWID(),'CompanyAdmin','COMPANYADMIN',NEWID() );


INSERT INTO CommonDropdowns VALUES (1,GETDATE(),'Female',1,0);
INSERT INTO CommonDropdowns VALUES (1,GETDATE(),'Male',1,0);

INSERT INTO CommonDropdowns VALUES (2,GETDATE(),'Christianity',1,0);
INSERT INTO CommonDropdowns VALUES (2,GETDATE(),'Islamic',1,0);
INSERT INTO CommonDropdowns VALUES (2,GETDATE(),'Judaism',1,0);
INSERT INTO CommonDropdowns VALUES (2,GETDATE(),'Paganism',1,0);


INSERT INTO CommonDropdowns VALUES (3,GETDATE(),'Agent',1,0);
INSERT INTO CommonDropdowns VALUES (3,GETDATE(),'Bank',1,0);
INSERT INTO CommonDropdowns VALUES (3,GETDATE(),'Bussiness',1,0);
INSERT INTO CommonDropdowns VALUES (3,GETDATE(),'Hospital',1,0);
INSERT INTO CommonDropdowns VALUES (3,GETDATE(),'School',1,0);
INSERT INTO CommonDropdowns VALUES (3,GETDATE(),'Security',1,0);
INSERT INTO CommonDropdowns VALUES (3,GETDATE(),'Transport',1,0);
INSERT INTO CommonDropdowns VALUES (3,GETDATE(),'Telecommunication',1,0);
INSERT INTO CommonDropdowns VALUES (3,GETDATE(),'software Technology',1,0);
