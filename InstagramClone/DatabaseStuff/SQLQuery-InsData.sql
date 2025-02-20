CREATE TABLE [User] (
    user_id INT PRIMARY KEY IDENTITY(1,1),
    username NVARCHAR(50) UNIQUE NOT NULL,
    password_hash NVARCHAR(255) NOT NULL,
    email NVARCHAR(100) UNIQUE NOT NULL,
    bio TEXT,
    profile_picture NVARCHAR(255),
    NumFollower INT DEFAULT 0,
    NumFollowing INT DEFAULT 0,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);

CREATE TABLE Post (
    post_id INT PRIMARY KEY IDENTITY(1,1),
    user_id INT NOT NULL,
    caption TEXT,
    image_url NVARCHAR(255) NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES [User](user_id) ON DELETE NO ACTION
);

CREATE TABLE Story (
    story_id INT PRIMARY KEY IDENTITY(1,1),
    user_id INT NOT NULL,
    image_url NVARCHAR(255) NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES [User](user_id) ON DELETE NO ACTION
);

ALTER TABLE Story ADD expires_at AS DATEADD(HOUR, 24, created_at) PERSISTED;

CREATE TABLE Comment (
    comment_id INT PRIMARY KEY IDENTITY(1,1),
    post_id INT NOT NULL,
    user_id INT NOT NULL,
    text TEXT NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (post_id) REFERENCES Post(post_id) ON DELETE NO ACTION,
    FOREIGN KEY (user_id) REFERENCES [User](user_id) ON DELETE NO ACTION
);

CREATE TABLE UserInteraction (
    interaction_id INT PRIMARY KEY IDENTITY(1,1),
    user_id INT NOT NULL,
    post_id INT,
    story_id INT,
    interaction_type NVARCHAR(10) CHECK (interaction_type IN ('like', 'save')),
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES [User](user_id) ON DELETE NO ACTION,
    FOREIGN KEY (post_id) REFERENCES Post(post_id) ON DELETE NO ACTION,
    FOREIGN KEY (story_id) REFERENCES Story(story_id) ON DELETE NO ACTION
);

CREATE TABLE Follow (
    follow_id INT PRIMARY KEY IDENTITY(1,1),
    follower_id INT NOT NULL,
    followed_id INT NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (follower_id) REFERENCES [User](user_id) ON DELETE NO ACTION,
    FOREIGN KEY (followed_id) REFERENCES [User](user_id) ON DELETE NO ACTION,
    UNIQUE (follower_id, followed_id)
);

CREATE TABLE DirectMessage (
    message_id INT PRIMARY KEY IDENTITY(1,1),
    sender_id INT NOT NULL,
    receiver_id INT NOT NULL,
    message_text TEXT NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    is_read BIT DEFAULT 0,
    FOREIGN KEY (sender_id) REFERENCES [User](user_id) ON DELETE NO ACTION,
    FOREIGN KEY (receiver_id) REFERENCES [User](user_id) ON DELETE NO ACTION
);

CREATE TABLE StoryView (
    view_id INT PRIMARY KEY IDENTITY(1,1),
    user_id INT NOT NULL,
    story_id INT NOT NULL,
    viewed_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES [User](user_id) ON DELETE NO ACTION,
    FOREIGN KEY (story_id) REFERENCES Story(story_id) ON DELETE NO ACTION
);

INSERT INTO [User] (username, password_hash, email, bio, profile_picture, NumFollower, NumFollowing)
VALUES 
('cristiano', 'hashedpassword1', 'cr7@example.com', 'Football player', NULL, 500000, 300),
('messi', 'hashedpassword2', 'messi@example.com', 'Goat of football', NULL, 600000, 400),
('serenawilliams', 'hashedpassword3', 'serena@example.com', 'Tennis Legend', NULL, 200000, 150),
('that_talkative_user', 'hashedpassword4', 'talkative@example.com', 'Loves chatting', NULL, 100, 500),
('aplasticplant', 'hashedpassword5', 'plant@example.com', 'Loves gardening', NULL, 10000, 800),
('movie_quotes', 'hashedpassword6', 'movie@example.com', 'Loves movie quotes', NULL, 500, 300),
('lifeoftheparty', 'hashedpassword7', 'party@example.com', 'Always at the best parties', NULL, 700, 600),
('user1', 'hash1', 'user1@example.com', 'Random user 1', 'pic1.jpg', 10, 15),
('user2', 'hash2', 'user2@example.com', 'Random user 2', 'pic2.jpg', 5, 7),
('user3', 'hash3', 'user3@example.com', 'Random user 3', NULL, 1000, 20),
('user4', 'hash4', 'user4@example.com', 'Random user 4', NULL, 1200, 50),
('user5', 'hash5', 'user5@example.com', 'Random user 5', NULL, 300, 100);

INSERT INTO Follow (follower_id, followed_id)
VALUES 
(2, 1), -- messi follows cristiano
(8, 1), -- user1 follows cristiano
(9, 1), -- user2 follows cristiano
(10, 1), -- user3 follows cristiano
(3, 2), -- serena follows messi
(5, 2), -- aplasticplant follows messi
(7, 2), -- lifeoftheparty follows messi
(4, 6), -- that_talkative_user follows movie_quotes
(6, 7), -- movie_quotes follows lifeoftheparty
(7, 5); -- lifeoftheparty follows aplasticplant

INSERT INTO Post (user_id, caption, image_url, created_at)
VALUES 
(2, 'Winning another game!', 'messi_goal.jpg', DATEADD(DAY, -3, GETDATE())),
(5, 'New plant update!', 'plant.jpg', DATEADD(DAY, -5, GETDATE())),
(1, 'Training hard!', 'cr7_training.jpg', DATEADD(DAY, -10, GETDATE())),
(3, 'Tennis practice!', 'serena_training.jpg', DATEADD(DAY, -7, GETDATE())),
(7, 'Party night!', 'party.jpg', DATEADD(DAY, -2, GETDATE()));

INSERT INTO Story (user_id, image_url, created_at)
VALUES 
(2, 'messi_story.jpg', DATEADD(HOUR, -12, GETDATE())),
(3, 'serena_story.jpg', DATEADD(HOUR, -22, GETDATE())),
(5, 'plant_story.jpg', DATEADD(HOUR, -15, GETDATE())),
(7, 'party_story.jpg', DATEADD(HOUR, -5, GETDATE())),
(6, 'movie_story.jpg', DATEADD(HOUR, -8, GETDATE()));

INSERT INTO Comment (post_id, user_id, text, created_at)
VALUES 
(1, 3, 'Amazing goal!', DATEADD(DAY, -2, GETDATE())),
(2, 7, 'Nice plant!', DATEADD(DAY, -4, GETDATE())),
(3, 5, 'Keep training!', DATEADD(DAY, -9, GETDATE())),
(4, 2, 'Love it!', DATEADD(DAY, -6, GETDATE())),
(5, 6, 'Great party!', DATEADD(DAY, -1, GETDATE()));

INSERT INTO UserInteraction (user_id, post_id, interaction_type, created_at)
VALUES 
(3, 1, 'like', DATEADD(DAY, -2, GETDATE())),
(5, 2, 'like', DATEADD(DAY, -4, GETDATE())),
(2, 4, 'like', DATEADD(DAY, -6, GETDATE())),
(6, 5, 'like', DATEADD(DAY, -1, GETDATE())),
(7, 3, 'like', DATEADD(DAY, -8, GETDATE()));

INSERT INTO UserInteraction (user_id, story_id, interaction_type, created_at)
VALUES 
(3, 1, 'like', DATEADD(HOUR, -11, GETDATE())),
(5, 2, 'like', DATEADD(HOUR, -20, GETDATE())),
(2, 3, 'like', DATEADD(HOUR, -14, GETDATE())),
(6, 4, 'like', DATEADD(HOUR, -3, GETDATE())),
(7, 5, 'like', DATEADD(HOUR, -7, GETDATE()));

INSERT INTO DirectMessage (sender_id, receiver_id, message_text, created_at, is_read)
VALUES 
(4, 6, 'Hey, how are you?', '2022-03-12 07:30:00', 1),
(4, 6, 'Let¡¯s catch up!', '2022-05-15 10:45:00', 0),
(4, 6, 'Are you free tomorrow?', '2022-09-20 14:15:00', 1),
(4, 6, 'Good morning!', '2022-12-04 16:50:00', 1),
(7, 5, 'Nice post!', '2023-01-10 09:00:00', 1);

INSERT INTO StoryView (user_id, story_id, viewed_at)
VALUES 
(3, 1, DATEADD(HOUR, -10, GETDATE())),
(5, 2, DATEADD(HOUR, -18, GETDATE())),
(2, 3, DATEADD(HOUR, -12, GETDATE())),
(6, 4, DATEADD(HOUR, -4, GETDATE())),
(7, 5, DATEADD(HOUR, -6, GETDATE()));
