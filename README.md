#Rebuy-Forms-Rating

##What is this?
Rebuy-Forms-Rating is a Xamarin.Forms ActionSheet for rating the app in the appstores (Apple AppStore, Google PlayStore).

We are very eager about your feedback, so do not hesitate to create an issue or feel free to improve our code via a contribution.

###Features
 - Fully Xamarin.Forms compatible.

###Setup and Usage
1. Install the [package via nuget]() into your PCL and platform specific projects.
2. Initialize and add the call-check in the 'OnStart' in your application Class.

Example implementation:
```cs
protected override void OnStart()
{
        var ratingViewhandler = new RatingViewHandler
        {
        	UsesBeforeRating = 2
        };
        ratingViewHandler.CheckOpenRatingView("100000");
}
```

#### FAKE options / Tasks

Execute `bin/fake <taskname>` to run a task or `bin/fake --<optionname>` for fake cli options. First run `bin/fake install`.

Available tasks:

```
* Restore
  Clean solution and afterwards restore all packages

* Build
  Build all projects of solution

```
