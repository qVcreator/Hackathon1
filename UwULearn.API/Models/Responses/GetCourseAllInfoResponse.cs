﻿using UwULearn.Data.Entities;

namespace UwULearn2.API.Models.Responses;

public class GetCourseAllInfoResponse : GetAllCoursesResponse
{
    public List<Lesson> Lessons { get; set; }
}
