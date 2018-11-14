package md5a9a3cb1503f784ed6bfba90f2ff3c975;


public class PanelUsuarios_RecyclerAdapter_MyView
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("CemAppAndroid.PanelUsuarios+RecyclerAdapter+MyView, CemAppAndroid", PanelUsuarios_RecyclerAdapter_MyView.class, __md_methods);
	}


	public PanelUsuarios_RecyclerAdapter_MyView (android.view.View p0)
	{
		super (p0);
		if (getClass () == PanelUsuarios_RecyclerAdapter_MyView.class)
			mono.android.TypeManager.Activate ("CemAppAndroid.PanelUsuarios+RecyclerAdapter+MyView, CemAppAndroid", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
