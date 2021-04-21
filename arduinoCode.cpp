#include "Keyboard.h"
#include "Mouse.h"

void setup()
{
	Serial.begin(57600);
	Keyboard.begin();
	Mouse.begin();
}

String get_action(String value)
{
	return value.substring(value.indexOf("*") + 1);
}

void keyboard_press(String value)
{
	Keyboard.press(char(value[0]));
}

void keyboard_print(String value)
{
	Keyboard.print(value);
}

void keyboard_println(String value)
{
	Keyboard.println(value);
}

void keyboard_release(String value)
{
	Keyboard.release(char(value[0]));
}

void keyboard_release_all()
{
	Keyboard.releaseAll();
}

void keyboard_write(String value)
{
	Keyboard.print(char(value[0]));
}

void mouse_click(String value)
{
	if (value == "LEFT")
		Mouse.click(MOUSE_LEFT);
	if (value == "RIGHT")
		Mouse.click(MOUSE_RIGHT);
	if (value == "MIDDLE")
		Mouse.click(MOUSE_MIDDLE);
}

void mouse_move(String value)
{
	int x = value.substring(0, value.indexOf(",")).toInt();
	int y = value.substring(value.indexOf(",") + 1).toInt();
	Mouse.move(x, y);
}

void mouse_press(String value)
{
	if (value == "LEFT")
		Mouse.press(MOUSE_LEFT);
	if (value == "RIGHT")
		Mouse.press(MOUSE_RIGHT);
	if (value == "MIDDLE")
		Mouse.press(MOUSE_MIDDLE);
}

void mouse_release(String value)
{
	if (value == "LEFT")
		Mouse.release(MOUSE_LEFT);
	if (value == "RIGHT")
		Mouse.release(MOUSE_RIGHT);
	if (value == "MIDDLE")
		Mouse.release(MOUSE_MIDDLE);
}

void loop()
{
	if (Serial.available() > 0)
	{
		String raw_data = Serial.readStringUntil('!');

		if (raw_data.indexOf("delay") > -1)
		{
			delay(get_action(raw_data).toInt());
		}

		if (raw_data.indexOf("keyboardPress") > -1)
		{
			keyboard_press(get_action(raw_data));
		}
		if (raw_data.indexOf("keyboardPrint") > -1)
		{
			keyboard_print(get_action(raw_data));
		}
		if (raw_data.indexOf("keyboardPrintln") > -1)
		{
			keyboard_println(get_action(raw_data));
		}
		if (raw_data.indexOf("keyboardRelease") > -1)
		{
			keyboard_release(get_action(raw_data));
		}
		if (raw_data.indexOf("keyboardReleaseAll") > -1)
		{
			keyboard_release_all();
		}
		if (raw_data.indexOf("keyboardWrite") > -1)
		{
			keyboard_write(get_action(raw_data));
		}
		if (raw_data.indexOf("mouseClick") > -1)
		{
			mouse_click(get_action(raw_data));
		}
		if (raw_data.indexOf("mouseMove") > -1)
		{
			mouse_move(get_action(raw_data));
		}
		if (raw_data.indexOf("mousePress") > -1)
		{
			mouse_press(get_action(raw_data));
		}
		if (raw_data.indexOf("mouseRelease") > -1)
		{
			mouse_release(get_action(raw_data));
		}
	}
}
