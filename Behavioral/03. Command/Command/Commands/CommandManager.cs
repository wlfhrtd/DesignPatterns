﻿using System.Collections.Generic;


namespace Command.Commands
{
    public class CommandManager
    {
        private Stack<ICommand> commands = new();

        public void Invoke(ICommand command)
        {
            if (command.CanExecute())
            {
                commands.Push(command);
                command.Execute();
            }
        }

        public void Undo()
        {
            while (commands.Count > 0)
            {
                var command = commands.Pop();
                command.Undo();
            }
        }
    }
}
