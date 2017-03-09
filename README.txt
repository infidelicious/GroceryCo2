Design choice limitations:
	built-in .net XML serialization
		I'm using the built in .net serialization which needs a couple "boundary crossing" references to work.
		Ideally I would use a serialization/rehydration library that didn't have this downfall.
		For example, in order to serialize a subclass, it needs an attribute referencing the subclass placed in the superclass which is an abomination
		This also impacted my separation of the Promotion based classes.  I would have preferred to have them in their own project so that promotions could be added at will without having to rebuild the core binaries.

		This also impacted my use of Interfaces.  Normally I would declare any object property as an interface and set the concrete type at runtime.  The .net serialization works fine with abstract and super/sub classes and will embed the full concrete class name but won't do that with interfaces.  I tried to feign interfaces with abstract classes but it was making a mess so I stopped.  Unfortunately I ended up

		I went forward with this serialization limitation because I wanted to focus on solving the problem rather than fiddling around with an unknown serialization library.  It also kept the serizliation/rehydration fairly simple.

		I wasn't completely satisfied with my Promotion implementation.  I think it was separated properly but how it interacted with the order line items needs more elegance and I certainly would have preferred they be in their own assembly.
		
		BindingList<T> - not really useful for web or console apps but I enjoy using this collection for the change notification properties and the <T>AddNew. combine that with the INotifyPropertyChange and it is very useful for MVC.

	I typically build a controller that talks to an inteface of a View and Entities (interfaces of models).  I create a view to implement the interface so that I can "skin" and swap view implementations and prevent.  when the view has controls, I use a base class such as "ICombo", "ILabel", etc...  This way the controller can bind (two way binding) a .net or infragistics or telerik control without having to be strongly bound to any of the offerings.

	When working with real models, everything gets an interface and is accessed via interfaces.  This lets me keep a good segregation of control/data/model logic.  I would declare the "Entities" as interfaces, the data layer speaks with those items, the models implement those interfaces.  As with the view, the controls bind to an an interface in a neutral zone and don't need to be aware of the model.

===============================================================================
Bugs:
	I began with test driven development and it served me well for the simple classes, data layer, etc...
	As time drew on, I was not able to keep up on my unit and integration tests.  I would have liked to add more around the promotion testing so there are more uknowns there.

	Running the app with a 2001-01-01 ends up listing all Apples.  I have not investigated yet.
===============================================================================
Limitations:
	Mostly time related.
	I did not have time to to implement a BOGO promotion but it is stubbed in.
	I stubbed out but did not implement a way to tell the user about products that were not priced.
		The app shows the groupd and counted items before pricing but then the products without pricing entries are not listed in the following output.
	Unable to to add promotions dynamically due to the serizliation I used.
	I did not have time to separate all my hard coded messages/strings.  I would have preferred loading these from config file(s).
	I wanted more unit and integration tests but needed to advance on the core processing logic.
	The order processing date is missing from the output but it is visible when run from the commandline.
	The application does not adress taxation
	I should have passed the view in as a parameter or on the constructor of the controller.
	I would have liked to build out the custom exceptions in the layers and give more thought to their handling and reporting to the user.
	
===============================================================================
Usability:
	The app neds 3 files to run and is called from the command line with at least 1 shopping list file (Order001.xml) and an optional date.  If the date is not supplied, it uses the current datetime.
		promotions.xml	- The current list of promotions, can be modified by adding valid XML sections.  The filename is hardcoded.
		catalog.xml - the current pricing list of products, can also be modified by adding valid XML sections.  The filename is hardcoded.
		an Order xml (Order001.xml).

	There are some generated XML files in the testing project bin/debug.  I used the tests to generate the files and then modified from there and coppied those to the program bin\debug:  kiosk\bin\Debug
There is a "TestRun.bat" file in "kiosk\bin\Debug" that runs the application with different date parameters but only uses one "Order001.xml" file.

	
