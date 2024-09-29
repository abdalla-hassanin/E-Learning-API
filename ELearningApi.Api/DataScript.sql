-- Insert ApplicationUsers
INSERT INTO AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount, FirstName, LastName, CreatedAt, UpdatedAt, RefreshToken, RefreshTokenExpiryTime)
VALUES
    (NEWID(), 'admin@example.com', 'ADMIN@EXAMPLE.COM', 'admin@example.com', 'ADMIN@EXAMPLE.COM', 1, 'AQAAAAIAAYagAAAAEPPQfTCxFBz5OUtOL9Z3Vb3b9fDCHI3QKciK9ENWE+qCXs2Qx2Zl3gLc+Hbqyhs6wg==', 'VVPCRDAS3MJWQD5CSW2GWPRADBAXSIVP', NEWID(), NULL, 0, 0, NULL, 1, 0, 'Admin', 'User', GETDATE(), GETDATE(), '', GETDATE()),
    (NEWID(), 'teacher1@example.com', 'TEACHER1@EXAMPLE.COM', 'teacher1@example.com', 'TEACHER1@EXAMPLE.COM', 1, 'AQAAAAIAAYagAAAAEPPQfTCxFBz5OUtOL9Z3Vb3b9fDCHI3QKciK9ENWE+qCXs2Qx2Zl3gLc+Hbqyhs6wg==', 'KPJNLDAS3MJWQD5CSW2GWPRADBAXSIVP', NEWID(), NULL, 0, 0, NULL, 1, 0, 'Ahmed', 'Hassan', GETDATE(), GETDATE(), '', GETDATE()),
    (NEWID(), 'teacher2@example.com', 'TEACHER2@EXAMPLE.COM', 'teacher2@example.com', 'TEACHER2@EXAMPLE.COM', 1, 'AQAAAAIAAYagAAAAEPPQfTCxFBz5OUtOL9Z3Vb3b9fDCHI3QKciK9ENWE+qCXs2Qx2Zl3gLc+Hbqyhs6wg==', 'LMJNLDAS3MJWQD5CSW2GWPRADBAXSIVP', NEWID(), NULL, 0, 0, NULL, 1, 0, 'Fatma', 'Ali', GETDATE(), GETDATE(), '', GETDATE()),
    (NEWID(), 'student1@example.com', 'STUDENT1@EXAMPLE.COM', 'student1@example.com', 'STUDENT1@EXAMPLE.COM', 1, 'AQAAAAIAAYagAAAAEPPQfTCxFBz5OUtOL9Z3Vb3b9fDCHI3QKciK9ENWE+qCXs2Qx2Zl3gLc+Hbqyhs6wg==', 'NMKNLDAS3MJWQD5CSW2GWPRADBAXSIVP', NEWID(), NULL, 0, 0, NULL, 1, 0, 'Mohamed', 'Ibrahim', GETDATE(), GETDATE(), '', GETDATE()),
    (NEWID(), 'student2@example.com', 'STUDENT2@EXAMPLE.COM', 'student2@example.com', 'STUDENT2@EXAMPLE.COM', 1, 'AQAAAAIAAYagAAAAEPPQfTCxFBz5OUtOL9Z3Vb3b9fDCHI3QKciK9ENWE+qCXs2Qx2Zl3gLc+Hbqyhs6wg==', 'OPKNLDAS3MJWQD5CSW2GWPRADBAXSIVP', NEWID(), NULL, 0, 0, NULL, 1, 0, 'Aisha', 'Mohamed', GETDATE(), GETDATE(), '', GETDATE()),
    (NEWID(), 'student3@example.com', 'STUDENT3@EXAMPLE.COM', 'student3@example.com', 'STUDENT3@EXAMPLE.COM', 1, 'AQAAAAIAAYagAAAAEPPQfTCxFBz5OUtOL9Z3Vb3b9fDCHI3QKciK9ENWE+qCXs2Qx2Zl3gLc+Hbqyhs6wg==', 'QRKNLDAS3MJWQD5CSW2GWPRADBAXSIVP', NEWID(), NULL, 0, 0, NULL, 1, 0, 'Omar', 'Ahmed', GETDATE(), GETDATE(), '', GETDATE()),
    (NEWID(), 'student4@example.com', 'STUDENT4@EXAMPLE.COM', 'student4@example.com', 'STUDENT4@EXAMPLE.COM', 1, 'AQAAAAIAAYagAAAAEPPQfTCxFBz5OUtOL9Z3Vb3b9fDCHI3QKciK9ENWE+qCXs2Qx2Zl3gLc+Hbqyhs6wg==', 'STKNLDAS3MJWQD5CSW2GWPRADBAXSIVP', NEWID(), NULL, 0, 0, NULL, 1, 0, 'Nour', 'Hassan', GETDATE(), GETDATE(), '', GETDATE());

-- Insert Instructors
INSERT INTO Instructors (Id, UserId, Expertise, Biography)
VALUES
    (NEWID(), (SELECT Id FROM AspNetUsers WHERE Email = 'teacher1@example.com'), 'Ancient Egyptian History', 'Expert in Egyptology with 15 years of experience'),
    (NEWID(), (SELECT Id FROM AspNetUsers WHERE Email = 'teacher2@example.com'), 'Arabic Language', 'Certified Arabic language instructor with a focus on Egyptian dialect');

-- Insert Students
INSERT INTO Students (Id, UserId)
VALUES
    (NEWID(), (SELECT Id FROM AspNetUsers WHERE Email = 'student1@example.com')),
    (NEWID(), (SELECT Id FROM AspNetUsers WHERE Email = 'student2@example.com')),
    (NEWID(), (SELECT Id FROM AspNetUsers WHERE Email = 'student3@example.com')),
    (NEWID(), (SELECT Id FROM AspNetUsers WHERE Email = 'student4@example.com'));

-- Insert Categories
INSERT INTO Categories (Id, Name)
VALUES
    (NEWID(), 'Egyptian History'),
    (NEWID(), 'Arabic Language'),
    (NEWID(), 'Egyptian Culture'),
    (NEWID(), 'Egyptian Cuisine'),
    (NEWID(), 'Egyptian Art');

-- Insert Courses with EstimatedDuration as TimeSpan using DATEADD
INSERT INTO Courses (Id, Title, Description, ShortDescription, Price, CreatedAt, UpdatedAt, InstructorId, CategoryId, ThumbnailUrl, TrailerVideoUrl, Level, EstimatedDuration, PublishedAt, Prerequisites, LearningObjectives)
VALUES
    (NEWID(), 'Ancient Egyptian Civilization', 'Comprehensive course on Ancient Egyptian history and culture', 'Explore the wonders of Ancient Egypt', 49.99, GETDATE(), GETDATE(), (SELECT TOP 1 Id FROM Instructors WHERE Expertise = 'Ancient Egyptian History'), (SELECT TOP 1 Id FROM Categories WHERE Name = 'Egyptian History'), 'https://example.com/thumbnails/ancient-egypt.jpg', 'https://example.com/trailers/ancient-egypt.mp4', 0, DATEADD(HOUR, 20, 0), GETDATE(), '[]', '[]'),
    (NEWID(), 'Egyptian Arabic for Beginners', 'Learn the basics of Egyptian Arabic dialect', 'Start speaking Egyptian Arabic today', 39.99, GETDATE(), GETDATE(), (SELECT TOP 1 Id FROM Instructors WHERE Expertise = 'Arabic Language'), (SELECT TOP 1 Id FROM Categories WHERE Name = 'Arabic Language'), 'https://example.com/thumbnails/egyptian-arabic.jpg', 'https://example.com/trailers/egyptian-arabic.mp4', 0, DATEADD(HOUR, 15, 0), GETDATE(), '[]', '[]'),
    (NEWID(), 'Modern Egyptian Culture', 'Explore contemporary Egyptian society and customs', 'Understand modern Egypt', 29.99, GETDATE(), GETDATE(), (SELECT TOP 1 Id FROM Instructors WHERE Expertise = 'Ancient Egyptian History'), (SELECT TOP 1 Id FROM Categories WHERE Name = 'Egyptian Culture'), 'https://example.com/thumbnails/modern-egypt.jpg', 'https://example.com/trailers/modern-egypt.mp4', 0, DATEADD(HOUR, 10, 0), GETDATE(), '[]', '[]'),
    (NEWID(), 'Egyptian Cooking Masterclass', 'Learn to cook authentic Egyptian dishes', 'Master Egyptian cuisine', 59.99, GETDATE(), GETDATE(), (SELECT TOP 1 Id FROM Instructors WHERE Expertise = 'Arabic Language'), (SELECT TOP 1 Id FROM Categories WHERE Name = 'Egyptian Cuisine'), 'https://example.com/thumbnails/egyptian-cooking.jpg', 'https://example.com/trailers/egyptian-cooking.mp4', 1, DATEADD(HOUR, 25, 0), GETDATE(), '[]', '[]'),
    (NEWID(), 'Ancient Egyptian Art and Architecture', 'Discover the beauty of Ancient Egyptian art', 'Explore Egyptian art history', 44.99, GETDATE(), GETDATE(), (SELECT TOP 1 Id FROM Instructors WHERE Expertise = 'Ancient Egyptian History'), (SELECT TOP 1 Id FROM Categories WHERE Name = 'Egyptian Art'), 'https://example.com/thumbnails/egyptian-art.jpg', 'https://example.com/trailers/egyptian-art.mp4', 0, DATEADD(HOUR, 18, 0), GETDATE(), '[]', '[]');

-- Insert Sections
INSERT INTO Sections (Id, Title, Description, OrderIndex, CourseId)
VALUES
    (NEWID(), 'Introduction to Ancient Egypt', 'Overview of Ancient Egyptian timeline', 1, (SELECT TOP 1 Id FROM Courses WHERE Title = 'Ancient Egyptian Civilization')),
    (NEWID(), 'Egyptian Arabic Alphabet', 'Learn the Arabic alphabet used in Egypt', 1, (SELECT TOP 1 Id FROM Courses WHERE Title = 'Egyptian Arabic for Beginners')),
    (NEWID(), 'Egyptian Family Life', 'Understanding modern Egyptian family structures', 1, (SELECT TOP 1 Id FROM Courses WHERE Title = 'Modern Egyptian Culture')),
    (NEWID(), 'Egyptian Breakfast Dishes', 'Popular breakfast recipes in Egypt', 1, (SELECT TOP 1 Id FROM Courses WHERE Title = 'Egyptian Cooking Masterclass')),
    (NEWID(), 'Ancient Egyptian Sculpture', 'Exploring famous Egyptian sculptures', 1, (SELECT TOP 1 Id FROM Courses WHERE Title = 'Ancient Egyptian Art and Architecture'));

-- Insert Lectures
INSERT INTO Lectures (Id, Title, Description, Content, Duration, OrderIndex, SectionId, Type, VideoUrl)
VALUES
    (NEWID(), 'The Old Kingdom', 'Exploring the Old Kingdom period', 'Content about the Old Kingdom', '00:45:00', 1, (SELECT TOP 1 Id FROM Sections WHERE Title = 'Introduction to Ancient Egypt'), 0, 'https://example.com/videos/old-kingdom.mp4'),
    (NEWID(), 'Arabic Consonants', 'Learning Arabic consonants', 'Content about Arabic consonants', '00:30:00', 1, (SELECT TOP 1 Id FROM Sections WHERE Title = 'Egyptian Arabic Alphabet'), 0, 'https://example.com/videos/arabic-consonants.mp4'),
    (NEWID(), 'Egyptian Marriage Customs', 'Understanding Egyptian weddings', 'Content about Egyptian weddings', '00:40:00', 1, (SELECT TOP 1 Id FROM Sections WHERE Title = 'Egyptian Family Life'), 0, 'https://example.com/videos/egyptian-weddings.mp4'),
    (NEWID(), 'Cooking Ful Medames', 'How to prepare Ful Medames', 'Recipe and instructions for Ful Medames', '00:35:00', 1, (SELECT TOP 1 Id FROM Sections WHERE Title = 'Egyptian Breakfast Dishes'), 0, 'https://example.com/videos/ful-medames.mp4'),
    (NEWID(), 'The Great Sphinx', 'Analyzing the Great Sphinx', 'Content about the Great Sphinx', '00:50:00', 1, (SELECT TOP 1 Id FROM Sections WHERE Title = 'Ancient Egyptian Sculpture'), 0, 'https://example.com/videos/great-sphinx.mp4');

-- Insert LectureResources
INSERT INTO LectureResources (Id, Title, Description, Url, Type, LectureId)
VALUES
    (NEWID(), 'Old Kingdom Timeline', 'Detailed timeline of the Old Kingdom', 'https://example.com/resources/old-kingdom-timeline.pdf', 0, (SELECT TOP 1 Id FROM Lectures WHERE Title = 'The Old Kingdom')),
    (NEWID(), 'Arabic Alphabet Chart', 'Printable Arabic alphabet chart', 'https://example.com/resources/arabic-alphabet.pdf', 0, (SELECT TOP 1 Id FROM Lectures WHERE Title = 'Arabic Consonants')),
    (NEWID(), 'Egyptian Wedding Traditions', 'Article on Egyptian wedding customs', 'https://example.com/resources/egyptian-weddings.pdf', 0, (SELECT TOP 1 Id FROM Lectures WHERE Title = 'Egyptian Marriage Customs')),
    (NEWID(), 'Ful Medames Recipe', 'Printable recipe for Ful Medames', 'https://example.com/resources/ful-medames-recipe.pdf', 0, (SELECT TOP 1 Id FROM Lectures WHERE Title = 'Cooking Ful Medames')),
    (NEWID(), 'Great Sphinx 3D Model', '3D model of the Great Sphinx', 'https://example.com/resources/great-sphinx-3d.obj', 5, (SELECT TOP 1 Id FROM Lectures WHERE Title = 'The Great Sphinx'));

-- Insert Enrollments
INSERT INTO Enrollments (Id, StudentId, CourseId, EnrolledAt, CompletedAt, Status, Progress)
VALUES
    (NEWID(), (SELECT TOP 1 Id FROM Students WHERE UserId = (SELECT Id FROM AspNetUsers WHERE Email = 'student1@example.com')), (SELECT TOP 1 Id FROM Courses WHERE Title = 'Ancient Egyptian Civilization'), GETDATE(), NULL, 1, 0.25),
    (NEWID(), (SELECT TOP 1 Id FROM Students WHERE UserId = (SELECT Id FROM AspNetUsers WHERE Email = 'student2@example.com')), (SELECT TOP 1 Id FROM Courses WHERE Title = 'Egyptian Arabic for Beginners'), GETDATE(), NULL, 1, 0.10),
    (NEWID(), (SELECT TOP 1 Id FROM Students WHERE UserId = (SELECT Id FROM AspNetUsers WHERE Email = 'student3@example.com')), (SELECT TOP 1 Id FROM Courses WHERE Title = 'Modern Egyptian Culture'), GETDATE(), NULL, 0, 0.00),
    (NEWID(), (SELECT TOP 1 Id FROM Students WHERE UserId = (SELECT Id FROM AspNetUsers WHERE Email = 'student4@example.com')), (SELECT TOP 1 Id FROM Courses WHERE Title = 'Egyptian Cooking Masterclass'), GETDATE(), NULL, 1, 0.50),
    (NEWID(), (SELECT TOP 1 Id FROM Students WHERE UserId = (SELECT Id FROM AspNetUsers WHERE Email = 'student1@example.com')), (SELECT TOP 1 Id FROM Courses WHERE Title = 'Ancient Egyptian Art and Architecture'), GETDATE(), GETDATE(), 2, 1.00);

-- Insert Progresses
INSERT INTO Progresses (Id, EnrollmentId, LectureId, StartedAt, CompletedAt, Status, ProgressPercentage)
VALUES
    (NEWID(), (SELECT TOP 1 Id FROM Enrollments WHERE CourseId = (SELECT TOP 1 Id FROM Courses WHERE Title = 'Ancient Egyptian Civilization')), (SELECT TOP 1 Id FROM Lectures WHERE Title = 'The Old Kingdom'), GETDATE(), DATEADD(HOUR, 1, GETDATE()), 2, 1.00),
    (NEWID(), (SELECT TOP 1 Id FROM Enrollments WHERE CourseId = (SELECT TOP 1 Id FROM Courses WHERE Title = 'Egyptian Arabic for Beginners')), (SELECT TOP 1 Id FROM Lectures WHERE Title = 'Arabic Consonants'), GETDATE(), NULL, 1, 0.50),
    (NEWID(), (SELECT TOP 1 Id FROM Enrollments WHERE CourseId = (SELECT TOP 1 Id FROM Courses WHERE Title = 'Egyptian Cooking Masterclass')), (SELECT TOP 1 Id FROM Lectures WHERE Title = 'Cooking Ful Medames'), GETDATE(), DATEADD(HOUR, 2, GETDATE()), 2, 1.00),
    (NEWID(), (SELECT TOP 1 Id FROM Enrollments WHERE CourseId = (SELECT TOP 1 Id FROM Courses WHERE Title = 'Ancient Egyptian Art and Architecture')), (SELECT TOP 1 Id FROM Lectures WHERE Title = 'The Great Sphinx'), GETDATE(), DATEADD(HOUR, 3, GETDATE()), 2, 1.00);

-- Insert Payments
INSERT INTO Payments (Id, Amount, Status, Method, PaymentReferenceId, CreatedAt, UpdatedAt, StudentId, CourseId)
VALUES
    (NEWID(), 49.99, 1, 'Credit Card', 'PAY-123456', GETDATE(), GETDATE(), (SELECT TOP 1 Id FROM Students WHERE UserId = (SELECT Id FROM AspNetUsers WHERE Email = 'student1@example.com')), (SELECT TOP 1 Id FROM Courses WHERE Title = 'Ancient Egyptian Civilization')),
    (NEWID(), 39.99, 1, 'PayPal', 'PAY-789012', GETDATE(), GETDATE(), (SELECT TOP 1 Id FROM Students WHERE UserId = (SELECT Id FROM AspNetUsers WHERE Email = 'student2@example.com')), (SELECT TOP 1 Id FROM Courses WHERE Title = 'Egyptian Arabic for Beginners')),
    (NEWID(), 59.99, 1, 'Credit Card', 'PAY-345678', GETDATE(), GETDATE(), (SELECT TOP 1 Id FROM Students WHERE UserId = (SELECT Id FROM AspNetUsers WHERE Email = 'student4@example.com')), (SELECT TOP 1 Id FROM Courses WHERE Title = 'Egyptian Cooking Masterclass')),
    (NEWID(), 44.99, 1, 'Bank Transfer', 'PAY-901234', GETDATE(), GETDATE(), (SELECT TOP 1 Id FROM Students WHERE UserId = (SELECT Id FROM AspNetUsers WHERE Email = 'student1@example.com')), (SELECT TOP 1 Id FROM Courses WHERE Title = 'Ancient Egyptian Art and Architecture'));

-- Insert Reviews
INSERT INTO Reviews (Id, Rating, Comment, CreatedAt, UpdatedAt, StudentId, CourseId)
VALUES
    (NEWID(), 5, 'Excellent course on Ancient Egypt!', GETDATE(), GETDATE(), (SELECT TOP 1 Id FROM Students WHERE UserId = (SELECT Id FROM AspNetUsers WHERE Email = 'student1@example.com')), (SELECT TOP 1 Id FROM Courses WHERE Title = 'Ancient Egyptian Civilization')),
    (NEWID(), 4, 'Very helpful for learning Egyptian Arabic', GETDATE(), GETDATE(), (SELECT TOP 1 Id FROM Students WHERE UserId = (SELECT Id FROM AspNetUsers WHERE Email = 'student2@example.com')), (SELECT TOP 1 Id FROM Courses WHERE Title = 'Egyptian Arabic for Beginners')),
    (NEWID(), 5, 'Loved learning about Egyptian cuisine!', GETDATE(), GETDATE(), (SELECT TOP 1 Id FROM Students WHERE UserId = (SELECT Id FROM AspNetUsers WHERE Email = 'student4@example.com')), (SELECT TOP 1 Id FROM Courses WHERE Title = 'Egyptian Cooking Masterclass')),
    (NEWID(), 4, 'Fascinating insights into Egyptian art', GETDATE(), GETDATE(), (SELECT TOP 1 Id FROM Students WHERE UserId = (SELECT Id FROM AspNetUsers WHERE Email = 'student1@example.com')), (SELECT TOP 1 Id FROM Courses WHERE Title = 'Ancient Egyptian Art and Architecture'));

-- Insert Quizzes
INSERT INTO Quizzes (Id, Title, Description, Type, TimeLimit, PassingScore, IsRandomized, ShowCorrectAnswers, MaxAttempts, AvailableFrom, AvailableTo, CourseId, SectionId, CreatedAt, UpdatedAt)
VALUES
    (NEWID(), 'Ancient Egypt Quiz', 'Test your knowledge of Ancient Egypt', 0, 30, 70, 1, 1, 3, GETDATE(), DATEADD(YEAR, 1, GETDATE()), (SELECT TOP 1 Id FROM Courses WHERE Title = 'Ancient Egyptian Civilization'), (SELECT TOP 1 Id FROM Sections WHERE Title = 'Introduction to Ancient Egypt'), GETDATE(), GETDATE()),
    (NEWID(), 'Egyptian Arabic Basics', 'Check your understanding of basic Egyptian Arabic', 0, 20, 60, 1, 1, 2, GETDATE(), DATEADD(YEAR, 1, GETDATE()), (SELECT TOP 1 Id FROM Courses WHERE Title = 'Egyptian Arabic for Beginners'), (SELECT TOP 1 Id FROM Sections WHERE Title = 'Egyptian Arabic Alphabet'), GETDATE(), GETDATE());

-- Insert QuizQuestions
INSERT INTO QuizQuestions (Id, QuestionText, Type, Points, DifficultyLevel, Explanation, OrderIndex, QuizId)
VALUES
    (NEWID(), 'Who was the first pharaoh of Ancient Egypt?', 0, 10, 2, 'Narmer is considered the first pharaoh of unified Egypt.', 1, (SELECT TOP 1 Id FROM Quizzes WHERE Title = 'Ancient Egypt Quiz')),
    (NEWID(), 'What is the Arabic word for "Hello"?', 0, 5, 1, 'Marhaban is a common greeting in Arabic.', 1, (SELECT TOP 1 Id FROM Quizzes WHERE Title = 'Egyptian Arabic Basics'));

-- Insert QuizAnswers
INSERT INTO QuizAnswers (Id, AnswerText, IsCorrect, Explanation, OrderIndex, QuestionId)
VALUES
    (NEWID(), 'Narmer', 1, 'Correct! Narmer is considered the first pharaoh of unified Egypt.', 1, (SELECT TOP 1 Id FROM QuizQuestions WHERE QuestionText = 'Who was the first pharaoh of Ancient Egypt?')),
    (NEWID(), 'Khufu', 0, 'Incorrect. Khufu was a pharaoh of the Fourth Dynasty.', 2, (SELECT TOP 1 Id FROM QuizQuestions WHERE QuestionText = 'Who was the first pharaoh of Ancient Egypt?')),
    (NEWID(), 'Marhaban', 1, 'Correct! Marhaban means "Hello" in Arabic.', 1, (SELECT TOP 1 Id FROM QuizQuestions WHERE QuestionText = 'What is the Arabic word for "Hello"?')),
    (NEWID(), 'Shukran', 0, 'Incorrect. Shukran means "Thank you" in Arabic.', 2, (SELECT TOP 1 Id FROM QuizQuestions WHERE QuestionText = 'What is the Arabic word for "Hello"?'));

-- Insert QuizAttempts
INSERT INTO QuizAttempts (Id, StudentId, QuizId, StartTime, EndTime, Score, IsPassed)
VALUES
    (NEWID(), (SELECT TOP 1 Id FROM Students WHERE UserId = (SELECT Id FROM AspNetUsers WHERE Email = 'student1@example.com')), (SELECT TOP 1 Id FROM Quizzes WHERE Title = 'Ancient Egypt Quiz'), DATEADD(DAY, -1, GETDATE()), DATEADD(DAY, -1, GETDATE()), 80, 1),
    (NEWID(), (SELECT TOP 1 Id FROM Students WHERE UserId = (SELECT Id FROM AspNetUsers WHERE Email = 'student2@example.com')), (SELECT TOP 1 Id FROM Quizzes WHERE Title = 'Egyptian Arabic Basics'), DATEADD(DAY, -2, GETDATE()), DATEADD(DAY, -2, GETDATE()), 70, 1);

-- Insert AttemptAnswers
INSERT INTO AttemptAnswers (Id, QuizAttemptId, QuestionId, Response, IsCorrect, PointsEarned, TimeTaken)
VALUES
    (NEWID(), (SELECT TOP 1 Id FROM QuizAttempts WHERE QuizId = (SELECT TOP 1 Id FROM Quizzes WHERE Title = 'Ancient Egypt Quiz')), (SELECT TOP 1 Id FROM QuizQuestions WHERE QuestionText = 'Who was the first pharaoh of Ancient Egypt?'), 'Narmer', 1, 10, '00:01:30'),
    (NEWID(), (SELECT TOP 1 Id FROM QuizAttempts WHERE QuizId = (SELECT TOP 1 Id FROM Quizzes WHERE Title = 'Egyptian Arabic Basics')), (SELECT TOP 1 Id FROM QuizQuestions WHERE QuestionText = 'What is the Arabic word for "Hello"?'), 'Marhaban', 1, 5, '00:00:45');

-- Insert QuizQuestionMedia
INSERT INTO QuizQuestionMedia (Id, Url, Type, QuestionId)
VALUES
    (NEWID(), 'https://example.com/media/narmer-palette.jpg', 0, (SELECT TOP 1 Id FROM QuizQuestions WHERE QuestionText = 'Who was the first pharaoh of Ancient Egypt?')),
    (NEWID(), 'https://example.com/media/arabic-greeting.mp3', 1, (SELECT TOP 1 Id FROM QuizQuestions WHERE QuestionText = 'What is the Arabic word for "Hello"?'));