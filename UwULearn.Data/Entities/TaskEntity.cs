﻿namespace UwULearn.Data.Entities;

public class TaskEntity
{
    public int Id { get; set; }
    public string Descriotion { get; set; }
    public string Example { get; set; }
    public string CorrectAnswer { get; set; }
    public int Reward { get; set; }
}
