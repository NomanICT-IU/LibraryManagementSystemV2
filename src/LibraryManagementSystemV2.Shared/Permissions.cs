using System.Reflection;

namespace LibraryManagementSystemV2.Shared.Constants;

public static class Permissions
{
    public static IEnumerable<string> GetAll()
    {
        return typeof(Permissions)
            .GetNestedTypes(BindingFlags.Public)
            .SelectMany(type => type
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(field =>
                    field.IsLiteral &&
                    !field.IsInitOnly &&
                    field.FieldType == typeof(string))
                .Select(field => (string)field.GetValue(null)!));
    }

    public static class Book
    {
        public const string Create = "book.create";
        public const string Delete = "book.delete";
        public const string Read = "book.read";
        public const string Detail = "book.detail";
        public const string Update = "book.update";
        public const string All = "book.all";
    }

    public static class BookCopy
    {
        public const string Create = "bookcopy.create";
        public const string Delete = "bookcopy.delete";
        public const string Read = "bookcopy.read";
        public const string Update = "bookcopy.update";
        public const string All = "bookcopy.all";
    }

    public static class Member
    {
        public const string Create = "member.create";
        public const string Delete = "member.delete";
        public const string Read = "member.read";
        public const string Update = "member.update";
        public const string All = "member.all";
    }

    public static class BorrowRecord
    {
        public const string Create = "borrowrecord.create";
        public const string Delete = "borrowrecord.delete";
        public const string Read = "borrowrecord.read";
        public const string Update = "borrowrecord.update";
    }

    public static class Dashboard
    {
        public const string Read = "dashboard.read";
    }
}