

INSERT INTO Pages (Title, Content, CreatedBy, CreatedAt, UpdatedAt)
VALUES 
('Home', 'Welcome to the Wiki!', 'Admin', GETDATE(), GETDATE()),
('About', 'This is a simple wiki.', 'Admin', GETDATE(), GETDATE()),
('Contact', 'You can contact us at, well, we don''t have a contact form yet.', 'Admin', GETDATE(), GETDATE()),
('Help', 'This is the help page.', 'Admin', GETDATE(), GETDATE()),
('FAQ', 'This is the FAQ page.', 'Admin', GETDATE(), GETDATE())


INSERT INTO Tags (TagName)
VALUES 
('Home'),
('About'),
('Contact'),
('Help'),
('FAQ'),
('Wiki')


INSERT INTO PagesTags (PageId, TagId)
VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(1, 6),
(2, 6),
(3, 6),
(4, 6),
(5, 6)



