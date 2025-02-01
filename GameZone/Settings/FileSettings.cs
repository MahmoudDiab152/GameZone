namespace GameZone.Settings
{
	public static class FileSettings
	{
		public const string ImagesPath = "/assets/images/games";
		public const string AllowedExtensions = ".jpg,.jpeg,.png";
		public const int MaxFileSize = 1;
		public const int MaxFileSizeInBytes = MaxFileSize * 1024 * 1024;
	}
}
