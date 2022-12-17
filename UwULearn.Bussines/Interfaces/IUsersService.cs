﻿namespace UwULearn.Bussines.Interfaces;

public interface IUsersService
{
    public void ChangePassword(); //There is should be update model as param
    public void ChangeCatsSkin(int userId, int skinId);
    public void AddCourse(int userId, int courseId);
    public void RemoveCourse(int userId, int courseId);
}
