﻿using DataAccess.ErrorMessage;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessObject
{
    public class SubjectDAO
    {
        public static List<Subject> GetAllSubjects()
        {
            using (var db = new ECourseDBContext())
            {
                return db.Subjects.ToList();
            }
        }

        public static Subject GetSubjectById(String SubjectID)
        {
            using (var db = new ECourseDBContext())
            {
                return db.Subjects.FirstOrDefault(s => s.SubjectId == SubjectID);
            }
        }

        public static Subject CreateSubject(Subject Subject)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetSubjectById(Subject.SubjectId) != null)
                    {
                        throw new Exception(ErrorMessage.SubjectError.SUBJECT_EXITED);
                    }
                    db.Subjects.Add(Subject);
                    db.SaveChangesAsync();
                    return Subject;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }

        public static void UpdateSubject(Subject Subject)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetSubjectById(Subject.SubjectId) == null)
                    {
                        throw new Exception(ErrorMessage.SubjectError.SUBJECT_IS_NOT_EXITED);
                    }
                    db.Subjects.Update(Subject);
                    db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void DeleteSubject(String SubjectID)
        {
            using (var db = new ECourseDBContext())
            {
                try
                {
                    if (GetSubjectById(SubjectID) == null)
                    {
                        throw new Exception(ErrorMessage.SubjectError.SUBJECT_IS_NOT_EXITED);
                    }
                    Subject Subject = GetSubjectById(SubjectID);
                    db.Subjects.Remove(Subject);
                    db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
