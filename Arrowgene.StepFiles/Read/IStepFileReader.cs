﻿namespace Arrowgene.StepFiles.Read
{
    using Arrowgene.StepFiles.Model;

    public interface IStepFileReader
    {
        StepFile Read(byte[] file);

    }
}
