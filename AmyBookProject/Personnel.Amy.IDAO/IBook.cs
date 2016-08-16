// ***********************************************************************
// Assembly         : Personnel.Amy.IDAO
// Author           : Amy
// Created          : 02-22-2014
//
// Last Modified By : Amy
// Last Modified On : 02-22-2014
// ***********************************************************************
// <copyright file="IBook.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Data;
using Personnel.Amy.Model;

namespace Personnel.Amy.IDAO
{
    /// <summary>
    /// Interface IBook
    /// </summary>
    public interface IBook
    {
        /// <summary>
        /// Adds the book.
        /// </summary>
        /// <param name="trans">The trans.</param>
        /// <param name="conn">The connection.</param>
        /// <param name="model">The model.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool AddBook(IDbTransaction trans, IDbConnection conn, MBook model);

        /// <summary>
        /// Deletes the book.
        /// </summary>
        /// <param name="trans">The trans.</param>
        /// <param name="conn">The connection.</param>
        /// <param name="keyID">The key unique identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool DelBook(IDbTransaction trans, IDbConnection conn, string keyID);

        /// <summary>
        /// Gets the book by key unique identifier.
        /// </summary>
        /// <param name="trans">The trans.</param>
        /// <param name="conn">The connection.</param>
        /// <param name="keyID">The key unique identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool GetBookByKeyID(IDbTransaction trans, IDbConnection conn, string keyID);

        /// <summary>
        /// Updates the book.
        /// </summary>
        /// <param name="trans">The trans.</param>
        /// <param name="conn">The connection.</param>
        /// <param name="model">The model.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool UpdateBook(IDbTransaction trans, IDbConnection conn, MBook model);
    }
}
