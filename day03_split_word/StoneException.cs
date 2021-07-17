using System;

public class StoneException: Exception {
    public StoneException(string message): base(message)
    {
       
    }

    public  StoneException(string message, ASTree ast): base($"{message} {ast.Location}"){
        
    }
}