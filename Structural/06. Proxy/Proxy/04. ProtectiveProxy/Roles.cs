﻿namespace Proxy._04._ProtectiveProxy
{
    public enum Roles
    {
        Author,
        Editor,
    }

    // Author can create a new document
    // Author can update the name of the document, modify its content, and assign initial tags
    // Author can submit document for review by an Editor
    // Editor can edit tags
    // Editor can mark the document reviewed (sets DateReviewed)
    // Editor cannot modify Name or Content directly
    // possible Admin who can do anything
}
