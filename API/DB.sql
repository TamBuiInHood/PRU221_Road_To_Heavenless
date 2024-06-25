-- Tạo cơ sở dữ liệu PRUGame
CREATE DATABASE PRUGame;
GO

-- Sử dụng cơ sở dữ liệu PRUGame
USE PRUGame;
GO

-- Tạo bảng user với userid làm khóa chính
CREATE TABLE [user] (
    userid INT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(50) NOT NULL,
    password NVARCHAR(50) NOT NULL
);
GO

-- Tạo bảng LeaderBoard với userid làm khóa ngoại
CREATE TABLE LeaderBoard (
    id INT IDENTITY(1,1) PRIMARY KEY,
    userid INT NOT NULL,
    time FLOAT NOT NULL,
    FOREIGN KEY (userid) REFERENCES [user](userid)
);
GO

-- Thêm một số dữ liệu mẫu vào bảng user
INSERT INTO [user] (username, password) VALUES ('user1', 'password1');
INSERT INTO [user] (username, password) VALUES ('user2', 'password2');
GO

-- Thêm dữ liệu mẫu vào bảng LeaderBoard
-- Lấy userid của user1
DECLARE @user1Id INT;
SELECT @user1Id = userid FROM [user] WHERE username = 'user1';

-- Thêm user1 vào LeaderBoard
INSERT INTO LeaderBoard (userid, time) VALUES (@user1Id, 120.5);

-- Lấy userid của user2
DECLARE @user2Id INT;
SELECT @user2Id = userid FROM [user] WHERE username = 'user2';

-- Thêm user2 vào LeaderBoard
INSERT INTO LeaderBoard (userid, time) VALUES (@user2Id, 150.75);
GO

-- Kiểm tra các user trong bảng user
SELECT * FROM [user];
GO

-- Kiểm tra các dòng dữ liệu trong bảng LeaderBoard
SELECT * FROM LeaderBoard;
GO