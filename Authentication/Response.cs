﻿using System;
namespace AuthAuthenticationApi.Authentication
{
	public class Response<T>
	{
		public string Status { get; set; } = "";
		public string Message { get; set; } = "";
		public T Data { get; set; }

    }
}

