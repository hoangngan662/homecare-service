﻿namespace BE.Services
{
    public interface ISendMailService
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
