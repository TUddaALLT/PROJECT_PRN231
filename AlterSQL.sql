alter table users
add [otpCode] [varchar](5) null

alter table users
add [verified] [bit] not null DEFAULT 0 
