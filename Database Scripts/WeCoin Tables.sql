-- DROP TABLE users_coins;
-- DROP TABLE posts_reactions;
-- DROP TABLE posts;
-- DROP TABLE notifications;
-- DROP TABLE friendships;
-- DROP TABLE reactions;
-- DROP TABLE users;
-- DROP TABLE relationship_types;
-- DROP TABLE coins;


CREATE TABLE coins
(
  gid smallint NOT NULL IDENTITY,
  coin character varying(30),
  code character varying(10),
  CONSTRAINT coins_pkey PRIMARY KEY (gid)
);
GO

CREATE TABLE relationship_types
(
  gid smallint NOT NULL IDENTITY,
  relation character varying(30),
  CONSTRAINT relationship_pkey PRIMARY KEY (gid)
);
GO

CREATE TABLE users
(
  gid integer NOT NULL IDENTITY,
  user_name character varying(40),
  surname text,
  birthdate date,
  picture text,
  sex character(1),
  psw text,
  email character varying(100),
  CONSTRAINT users_pkey PRIMARY KEY (gid)
);
GO

CREATE TABLE reactions
(
  reaction_text character varying(20),
  image text,
  gid smallint NOT NULL IDENTITY,
  CONSTRAINT reactions_pkey PRIMARY KEY (gid)
);
GO

CREATE TABLE posts
(
  gid bigint NOT NULL IDENTITY,
  post_text text,
  image text,
  post_time datetime DEFAULT GETDATE() NOT NULL,
  user_id integer,
  CONSTRAINT posts_pkey PRIMARY KEY (gid),
  CONSTRAINT posts_user_fk FOREIGN KEY (user_id)
      REFERENCES users (gid) 
);
GO

CREATE TABLE posts_reactions
(
  post_id bigint,
  reaction_id smallint,
  user_id integer, -- The user which reacted to a post
  CONSTRAINT post_fk FOREIGN KEY (post_id)
      REFERENCES posts (gid) 
      ,
  CONSTRAINT reaction_fk FOREIGN KEY (reaction_id)
      REFERENCES reactions (gid) 
      ,
  CONSTRAINT user_fk FOREIGN KEY (user_id)
      REFERENCES users (gid) 
      ,
  CONSTRAINT posts_reactions_uk UNIQUE (post_id, user_id)
);
GO

CREATE TABLE notifications
(
  to_user integer NOT NULL,
  notification_time datetime DEFAULT GETDATE() NOT NULL,
  was_read bit NOT NULL DEFAULT 0,
  message text NOT NULL,
  CONSTRAINT user_notified_pkey FOREIGN KEY (to_user)
      REFERENCES users (gid)     
);
GO

CREATE TABLE users_coins
(
  user_id integer,
  coin_id smallint,
  CONSTRAINT coinuser_fk FOREIGN KEY (coin_id)
      REFERENCES coins (gid) 
      ,
  CONSTRAINT usercoin_fk FOREIGN KEY (user_id)
      REFERENCES users (gid) 
      ,
  CONSTRAINT users_coins_uk UNIQUE (user_id, coin_id)
);
GO

CREATE TABLE friendships
(
  gid integer NOT NULL IDENTITY,
  user_id integer NOT NULL,
  friend_id integer NOT NULL,
  relationship smallint NOT NULL,
  accepted bit,
  CONSTRAINT friendships_friend_fk FOREIGN KEY (friend_id)
      REFERENCES users (gid),
  CONSTRAINT friendships_relationship_fk FOREIGN KEY (relationship)
      REFERENCES relationship_types (gid),
  CONSTRAINT friendships_user_fk FOREIGN KEY (user_id)
      REFERENCES users (gid),
  CONSTRAINT friendships_friendship_uk UNIQUE (user_id, friend_id)
); 
GO

CREATE OR ALTER TRIGGER notify_friend
ON friendships
FOR INSERT
AS
BEGIN
    DECLARE @ACCEPTED BIT
    SET @ACCEPTED = (SELECT accepted FROM INSERTED);
      IF (@ACCEPTED = 1)
          BEGIN
              INSERT INTO notifications(to_user, message)
              SELECT 
                  INSERTED.friend_id, 
                  (SELECT user_name FROM users WHERE gid = INSERTED.user_id) + ' accepted your friend request.'
              FROM INSERTED;
          END
END
GO