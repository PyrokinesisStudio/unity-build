﻿
namespace SuperSystems.UnityBuild
{

[System.Serializable]
public class BuildNotification
{
    public enum Category
    {
        Notification,
        Warning,
        Error
    }

    public delegate bool ValidityCheck();

    public Category cat;
    public string title;
    public string details;
    public ValidityCheck valid;

    public BuildNotification(Category cat = Category.Notification, string title = null, string details = null, ValidityCheck valid = null)
    {
        this.cat = cat;
        this.title = title;
        this.details = details;
        this.valid = valid;
    }
}

}