﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.AspNet.Abstractions
{
    public static class UrlHelper
    {
        public static string CreateIssuerUrl(string orgUrl, string authorizationServerId)
        {
            if (string.IsNullOrEmpty(orgUrl))
            {
                throw new ArgumentNullException(nameof(orgUrl));
            }

            if (string.IsNullOrEmpty(authorizationServerId))
            {
                return orgUrl;
            }

            return $"{EnsureTrailingSlash(orgUrl)}oauth2/{authorizationServerId}";
        }

        /// <summary>
        /// Ensures that this URI ends with a trailing slash <c>/</c>.
        /// </summary>
        /// <param name="uri">The URI string.</param>
        /// <returns>The URI string, appended with <c>/</c> if necessary.</returns>
        public static string EnsureTrailingSlash(string uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                throw new ArgumentNullException(nameof(uri));
            }

            return uri.EndsWith("/")
                ? uri
                : $"{uri}/";
        }
    }
}