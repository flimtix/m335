namespace MemeChat.Service.Tests
{
    public static class SensorService
    {
        public static string CreateBase64String(Stream photo)
        {
            if (photo != null)
            {
                using var stream = photo;
                using var ms = new MemoryStream();

                stream.CopyTo(ms);
                var bytes = ms.ToArray();

                return "data:image/png;base64," + Convert.ToBase64String(bytes);
            }

            return string.Empty;
        }
    }
}
