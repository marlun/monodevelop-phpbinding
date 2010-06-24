using System;
using MonoDevelop.Ide.Gui.Content;

namespace PhpBinding.Formatting
{
	public class PhpTextEditorIndentation : TextEditorExtension
	{
		public override bool KeyPress (Gdk.Key key, char keyChar, Gdk.ModifierType modifier)
		{
			if (key == Gdk.Key.Return) 
			{
				string lastLine = Editor.GetLineText(Editor.CursorLine);
				string trimmedLine = lastLine.Trim();
				bool indent = false;
				
				if (trimmedLine.EndsWith("{"))
				{
					indent = true;
				}
				
				if (indent) {
					base.KeyPress(key, keyChar, modifier);
					Editor.InsertText(Editor.CursorPosition, "\t");
					return false;
				}
			}
			
			return base.KeyPress (key, keyChar, modifier);
		}
	}
}

