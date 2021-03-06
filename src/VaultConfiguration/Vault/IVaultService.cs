﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration.VaultConfiguration.Vault.Authentication;
using Microsoft.Extensions.Configuration.VaultConfiguration.Vault.Models;

namespace Microsoft.Extensions.Configuration.VaultConfiguration.Vault {

    /// <summary>
    /// The vault service. This is the entry point for vault communication.
    /// </summary>
    public interface IVaultService {

        /// <summary>
        /// Gets the rest client.
        /// </summary>
        HttpClient Client { get; }
        
        /// <summary>
        /// Authenticate to vault.
        /// </summary>
        /// <param name="vaultAuthentication">Authentication token.</param>        
        Task AuthenticateAsync(IVaultAuthentication vaultAuthentication);
        
        /// <summary>
        /// Read data as <see cref="SecretBundle"/> from Vault.
        /// </summary>        
        /// <param name="path">Path to a backend.</param>
        /// <param name="payload">Payload to send.</param>
        /// <returns>
        /// Reads data at the given path from Vault.This can be used to read 
        /// secrets and configuration as well as generate dynamic values from 
        /// materialized backends. Please reference the documentation for the 
        /// backends in use to determine key structure.
        /// </returns>
        Task<SecretBundle> ReadSecretAsync(string path, object payload = null);

        /// <summary>
        /// Read data as <see cref="SecretBundle"/> from Vault.
        /// </summary>
        /// <typeparam name="T">The type of the <code>Data</code> property.</typeparam>               
        /// <param name="path">Path to a backend.</param>
        /// <param name="payload">Payload to send.</param>
        /// <returns>
        /// Reads data at the given path from Vault.This can be used to read 
        /// secrets and configuration as well as generate dynamic values from 
        /// materialized backends. Please reference the documentation for the 
        /// backends in use to determine key structure.        
        /// </returns>
        Task<SecretBundle<T>> ReadSecretAsync<T>(string path, object payload = null);

        /// <summary>
        /// List data from Vault.
        /// </summary>        
        /// <param name="path">Path to a backend.</param>
        /// <returns> Retrieve a listing of available data. The data returned, 
        /// if any, is backend-and endpoint-specific. </returns>
        Task<IEnumerable<string>> ListAsync(string path);

        /// <summary>
        /// Gets health status info of Vault.
        /// </summary>
        /// <returns>Returns <see cref="HealthBundle"/> that describes the Vault's health info.</returns>
        Task<HealthBundle> HealthAsync();

        /// <summary>
        /// Check the health status of Vault.
        /// </summary>
        /// <returns>Returns an enumeration that describes the Vault status.</returns>
        Task<VaultHealthStatus> HealthStatusAsync();
    }

}
