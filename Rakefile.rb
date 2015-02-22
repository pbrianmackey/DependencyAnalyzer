require 'rake'
require 'open3'

desc "Usage: rake 'query[projectName,assemblyName]'.  Tells you if a project is referenced by another project somewhere in the chain (direct and transitive)"
task :query, [:arg1, :arg2] do |t, args|

	#puts "Project Name : ";
	#projectName = STDIN.gets.chomp;

	#puts "Assembly Name : (without .dll)";
	#assemblyName = STDIN.gets.chomp;
	#puts "args: #{args}"
	#puts "in a string: " + "#{args.arg1} #{args.arg2}"
	#puts "out of string: " +  args.arg1 + args.arg2


	#sh("RunSample.bat #{args.arg1} #{args.arg2}")

	commands = [
		#'"D:\Program Files (x86)\swipl\bin\swipl.exe" -q -l .\Sample.pro a(\'b\',\'c\')',
		#'"D:\Program Files (x86)\swipl\bin\swipl.exe" -q -l .\Sample.pro a(\'' + args.arg1 + "','" + args.arg2 + "')",
		'"D:\Program Files (x86)\swipl\bin\swipl.exe" -q -l .\Sample.pro projectReferences(\'' + args.arg1 + "','" + args.arg2 + "')",
		'"D:\Program Files (x86)\swipl\bin\swipl.exe" -q -l .\Sample.pro transitiveReference(\'' + args.arg1 + "','" + args.arg2 + "')",
		'"D:\Program Files (x86)\swipl\bin\swipl.exe" -q -l .\Sample.pro transitiveReferenceD1(\'' + args.arg1 + "','" + args.arg2 + "')",
		'"D:\Program Files (x86)\swipl\bin\swipl.exe" -q -l .\Sample.pro transitiveReferenceD2(\'' + args.arg1 + "','" + args.arg2 + "')"
	]

	#array = [1, 2, 3, 4, 5, 6]
    #array.each { |x| puts x }

    commands.each { |x| 
    	#puts x
    	stdin, stdout, stderr = Open3.popen3(x)
		
		puts stdout.read
	    unless (err = stderr.read).empty? then 
	        puts errc
	    end
		
    }
	
	
	#stdin, stdout, stderr = Open3.popen3('"D:\Program Files (x86)\swipl\bin\swipl.exe" -q -l .\Sample.pro projectReferences(\'#{args.arg1}\',\'#{args.arg2}\')')
	#stdin, stdout, stderr = Open3.popen3('"D:\Program Files (x86)\swipl\bin\swipl.exe" -q -l .\Sample.pro transitiveReference(\'#{args.arg1}\',\'#{args.arg2}\')')
	#stdin, stdout, stderr = Open3.popen3('"D:\Program Files (x86)\swipl\bin\swipl.exe" -q -l .\Sample.pro transitiveReferenceD1(\'#{args.arg1}\',\'#{args.arg2}\')')
	#stdin, stdout, stderr = Open3.popen3('"D:\Program Files (x86)\swipl\bin\swipl.exe" -q -l .\Sample.pro transitiveReferenceD2(\'#{args.arg1}\',\'#{args.arg2}\')')
	

	#stdin, stdout, stderr = Open3.popen3("RunSample.bat #{args.arg1} #{args.arg2}") 

	#puts stdout.read
	#puts stderr.gets
	
	#exec "RunSample.bat #{args.arg1} #{args.arg2}"
end