USE Giraffe;
CREATE TABLE profile (
	username VARCHAR(50) PRIMARY KEY UNIQUE,
	pass VARCHAR(50) NOT NULL,
	email VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE event (
	id BIGINT(100) AUTO_INCREMENT PRIMARY KEY UNIQUE,
	url VARCHAR(200),
	title VARCHAR(100),
	description VARCHAR(140),
	upvote BIGINT(255) DEFAULT '0',
	city VARCHAR(50),
	zipcode INTEGER(5),
	bloblocation VARCHAR(100),
	datatype VARCHAR(5),
	CONSTRAINT check_datatype CHECK (datatype IN ('Video', 'News'))
);

CREATE TABLE saved (
	eventid INTEGER(100),
    username VARCHAR(50),
	FOREIGN KEY(eventid) REFERENCES event(id),
	FOREIGN KEY(username) REFERENCES profile(username)
);

ALTER TABLE profile
ADD CONSTRAINT url_or_blob
CHECK (
	(url IS NULL AND bloblocation IS NOT NULL)
	OR (url IS NOT NULL AND bloblocation IS NULL)
);