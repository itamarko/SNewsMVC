using System;

namespace SNewsMVC.DataModel
{
    public class CommandResponseSNewsAPI<T>
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }
    }
}
