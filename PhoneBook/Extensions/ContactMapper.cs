using PhoneBook.Model;

namespace PhoneBook.Extensions;

internal static class ContactMapper
{
    public static ContactDto ToDto(this Contact contact) =>
        new()
        {
            Id = contact.Id,
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            PhoneNumber = contact.PhoneNumber,
            Email = contact.Email
        };

    public static Contact ToEntity(this ContactDto contactDto) =>
        new()
        {
            Id = contactDto.Id,
            FirstName = contactDto.FirstName,
            LastName = contactDto.LastName,
            PhoneNumber = contactDto.PhoneNumber,
            Email = contactDto.Email
        };
}