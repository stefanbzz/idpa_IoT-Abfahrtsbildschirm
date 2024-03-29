﻿/*
 * Wrapper library
 * 
 * Author: Stefan Thomsen
 * Date: 07.05.2023
 * Version: 1.0
 * 
 */
using idpa_IoT_Abfahrtsbildschirm.Models;

namespace idpa_IoT_Abfahrtsbildschirm.Interfaces
{
    public interface IApiWrapper
    {
        /// <summary>
        /// Display the Data from Search.ch with some of the optional parameters always on.
        /// </summary>
        /// <param name="stop"></param>
        /// <param name="limit"></param>
        /// <returns>A IEnumerable <see cref="Connection"/> list from the specified <param name="stop"></param> station  </returns>
        Task<IEnumerable<Connection>> GetConnections(string stop, int limit);
    }
}
