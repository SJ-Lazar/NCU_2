CREATE TABLE [dbo].[PagesTags]
(
	PageId INT FOREIGN KEY REFERENCES Pages(PageId),
    TagId INT FOREIGN KEY REFERENCES Tags(TagId),
    PRIMARY KEY (PageId, TagId)
)
