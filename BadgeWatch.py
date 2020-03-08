import kivy
from kivy.app import App
from kivy.uix.label import Label
kivy.require("1.10.1")


class BadgeWatchApp(App):
    def build(self):
        return Label(text="BadgeWatch coming soon.")


# Run the app.
if __name__ == "__main__":
    BadgeWatchApp().run()