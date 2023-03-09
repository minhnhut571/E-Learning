using System;
namespace DataAccess.ErrorMessage
{
    public static class ErrorMessage
    {
        #region Student Error Message
        public static class StudentError
        {
            public readonly static string STUDENT_EXITED = "Student exited";
            public readonly static string STUDENT_IS_NOT_EXITED = "Student isn't exited";
        }
        #endregion

        #region Teacher Error Message
        public static class TeacherError
        {
            public readonly static string TEACHER_EXITED = "Teacher exited";
            public readonly static string TEACHER_IS_NOT_EXITED = "Teacher isn't exited";
        }
        #endregion

        #region Major Error Message
        public static class MajorError
        {
            public readonly static string MAJOR_EXITED = "Major exited";
            public readonly static string MAJOR_IS_NOT_EXITED = "Major isn't exited";
        }
        #endregion
    }
}
