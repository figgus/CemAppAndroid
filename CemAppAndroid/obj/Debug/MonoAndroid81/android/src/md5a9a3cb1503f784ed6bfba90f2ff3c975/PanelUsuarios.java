package md5a9a3cb1503f784ed6bfba90f2ff3c975;


public class PanelUsuarios
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("CemAppAndroid.PanelUsuarios, CemAppAndroid", PanelUsuarios.class, __md_methods);
	}


	public PanelUsuarios ()
	{
		super ();
		if (getClass () == PanelUsuarios.class)
			mono.android.TypeManager.Activate ("CemAppAndroid.PanelUsuarios, CemAppAndroid", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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